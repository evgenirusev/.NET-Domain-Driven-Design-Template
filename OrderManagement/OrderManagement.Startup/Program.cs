var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddWebComponents();

var app = builder.Build();

app
    .UseWebService(app.Environment)
    .Initialize();

app.Run();