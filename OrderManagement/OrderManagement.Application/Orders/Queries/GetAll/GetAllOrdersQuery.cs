using MediatR;

public class GetAllOrdersQuery : IRequest<List<OrderListItem>>
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderListItem>>
    {
        private readonly IOrderQueryRepository orderRepository;
        private readonly IProductCatalogHttpService productCatalogHttpService;

        public GetAllOrdersQueryHandler(
            IOrderQueryRepository orderRepository,
            IProductCatalogHttpService productCatalogHttpService)
        {
            this.orderRepository = orderRepository;
            this.productCatalogHttpService = productCatalogHttpService;
        }

        public async Task<List<OrderListItem>> Handle(
            GetAllOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAll(cancellationToken);

            var productNames = await FetchProductNames(orders, cancellationToken);

            foreach (var item in orders.SelectMany(o => o.Items))
            {
                if (productNames.TryGetValue(item.ProductId, out var name))
                {
                    item.ProductName = name;
                }
            }

            return orders;
        }

        // Cross-context read enrichment over HTTP. One call per distinct ProductId,
        // deduped against the orders in this page. For high-traffic reads this should
        // be replaced with an event-driven projection (ProductAdded/ProductRenamed
        // -> denormalized ProductName onto the Order side).
        private async Task<Dictionary<Guid, string>> FetchProductNames(
            List<OrderListItem> orders,
            CancellationToken cancellationToken)
        {
            var productIds = orders
                .SelectMany(o => o.Items.Select(i => i.ProductId))
                .Distinct();

            var names = new Dictionary<Guid, string>();

            foreach (var productId in productIds)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var product = await productCatalogHttpService.GetProductById(productId.ToString());
                if (product is not null)
                {
                    names[product.Id] = product.Name;
                }
            }

            return names;
        }
    }
}
