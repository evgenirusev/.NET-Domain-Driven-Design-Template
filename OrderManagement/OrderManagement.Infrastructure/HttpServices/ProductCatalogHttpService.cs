using System.Net.Http.Json;
using OrderManagement.Application.Services;

public sealed class ProductCatalogHttpService : IProductCatalogHttpService
{
    private readonly HttpClient client;

    public ProductCatalogHttpService(HttpClient client)
    {
        this.client = client;
    }

    // TODO: use application level response
    public async Task<int> GetProductById(string id)
    {
        var content = await client.GetFromJsonAsync<int>($"products/{id}");
        return content;
    }
}