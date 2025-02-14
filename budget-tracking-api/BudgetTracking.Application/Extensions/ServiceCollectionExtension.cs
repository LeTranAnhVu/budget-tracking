using BudgetTracking.Application.Configs;
using BudgetTracking.Application.Repositories.User;
using BudgetTracking.Application.Services.AuthService;
using BudgetTracking.Application.Services.CategoryService;
using BudgetTracking.Application.Services.ExpenseService;
using BudgetTracking.Application.Services.SupCategoryService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracking.Application.Extensions;

public static class ServiceCollectionExtension
{
   public static IServiceCollection AddAppLayer(this IServiceCollection services, IConfigurationManager config)
   {
      services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));

      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IExpenseService, ExpenseService>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<ISupCategoryService, SupCategoryService>();
      return services;
   }
}

