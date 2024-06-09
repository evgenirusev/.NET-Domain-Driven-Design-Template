using BettingSystem.Application.Betting;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCommonWebComponents()
    .AddDomain()
    .AddApplication(builder.Configuration);

var app = builder.Build();

app.AddCommonAppComponents();

app.Run();