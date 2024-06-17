using System.Net.Http.Json;

public sealed class ProductCatalogHttpService : IProductCatalogHttpService
{
    private readonly HttpClient client;

    public ProductCatalogHttpService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ProductResponse?> GetProductById(string id)
        => await client.GetFromJsonAsync<ProductResponse>($"products/{id}");
}