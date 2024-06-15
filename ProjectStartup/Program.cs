var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddProductCatalogDomain()
    .AddProductCatalogApplication(builder.Configuration)
    .AddProductCatalogInfrastructure(builder.Configuration)
    .AddProductCatalogWebComponents();

builder
    .Services
    .AddOrderManagementDomain()
    .AddOrderManagementApplication(builder.Configuration)
    .AddOrderManagementInfrastructure(builder.Configuration)
    .AddOrderManagementWebComponents();

builder.Services
    .AddTokenAuthentication(builder.Configuration)
    .AddModelBinders()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Web API", Version = "v1" });
    });

var app = builder.Build();

app
    .UseWebService(app.Environment)
    .Initialize();

app.Run();