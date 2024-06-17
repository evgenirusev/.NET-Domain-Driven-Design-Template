public class ProductCatalogAPIClientSettings(string baseUrl)
{
    public string BaseUrl { get; set; } = baseUrl;
}

public class OrderManagementSettings(ProductCatalogAPIClientSettings productCatalogAPIClientSettings)
{
    public ProductCatalogAPIClientSettings ProductCatalogAPIClientSettings { get; set; } 
        = productCatalogAPIClientSettings;
}