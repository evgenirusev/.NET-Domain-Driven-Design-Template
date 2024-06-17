namespace OrderManagement.Application.Services;

public interface IProductCatalogHttpService
{
    public Task<int> GetProductById(string id);
}