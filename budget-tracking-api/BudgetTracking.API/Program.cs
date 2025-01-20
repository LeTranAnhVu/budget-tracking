using System.Text;
using BudgetTracking.API.Endpoints;
using BudgetTracking.API.Filters;
using BudgetTracking.API.Services;
using BudgetTracking.Application.Configs;
using BudgetTracking.Application.Extensions;
using BudgetTracking.Application.Services;
using BudgetTracking.Db.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserContext, UserHttpContext>();
builder.Services.AddScoped<HttpUserContextBuilderFilter>();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var settings = builder.Configuration.GetSection(nameof(JwtSettings));
    var secret = settings.GetValue<string>(nameof(JwtSettings.Secret)) ?? throw new NullReferenceException(nameof(JwtSettings.Secret));
    var issuer = settings.GetValue<string>(nameof(JwtSettings.Issuer)) ?? throw new NullReferenceException(nameof(JwtSettings.Issuer));
    var audience = settings.GetValue<string>(nameof(JwtSettings.Audience)) ?? throw new NullReferenceException(nameof(JwtSettings.Audience));

    opts.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ValidAudience = audience,
        ValidIssuer = issuer
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services
    .AddDbLayer(builder.Configuration)
    .AddAppLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-9.0
app.UseAuthentication();
app.UseAuthorization();

var api = app.MapGroup("api")
    .RequireAuthorization()
    .AddEndpointFilter<HttpUserContextBuilderFilter>();

api.MapGet("test", (IUserContext userContext) =>
{
    var currentUser = userContext.CurrentUser;
    return currentUser.Id;
});

api.AddAuthEndpoints();

app.Run();
