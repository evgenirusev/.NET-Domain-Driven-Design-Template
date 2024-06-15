using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .PAddDomain()
    .PAddApplication(builder.Configuration)
    .PAddInfrastructure(builder.Configuration)
    .PAddWebComponents();

builder
    .Services
    .OAddDomain()
    .OAddApplication(builder.Configuration)
    .OAddInfrastructure(builder.Configuration)
    .OAddWebComponents();

var secret = builder.Configuration
    .GetSection(nameof(ApplicationSettings))
    .GetValue<string>(nameof(ApplicationSettings.Secret));

var key = Encoding.ASCII.GetBytes(secret);

builder.Services
    .AddAuthentication(authentication =>
    {
        authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(bearer =>
    {
        bearer.RequireHttpsMetadata = false;
        bearer.SaveToken = true;
        bearer.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddHttpContextAccessor();

builder
    .Services.Configure<ApiBehaviorOptions>(options => options
    .SuppressModelStateInvalidFilter = true);

builder
    .Services.AddControllers(options => options
    .ModelBinderProviders
    .Insert(0, new ImageModelBinderProvider()));

builder
    .Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Web API", Version = "v1" });
});

var app = builder.Build();

app
    .UseWebService(app.Environment)
    .Initialize();

app.Run();