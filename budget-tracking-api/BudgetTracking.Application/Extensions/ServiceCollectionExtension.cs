using BudgetTracking.Application.Configs;
using BudgetTracking.Application.Repositories.User;
using BudgetTracking.Application.Services.AuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracking.Application.Extensions;

public static class ServiceCollectionExtension
{
   public static IServiceCollection AddAppLayer(this IServiceCollection services, IConfigurationManager config)
   {
      services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IUserRepository, UserRepository>();
      return services;
   }
}

