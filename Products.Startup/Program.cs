var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCommonWebComponents();
var app = builder.Build();
app.AddCommonAppComponents();
app.Run();