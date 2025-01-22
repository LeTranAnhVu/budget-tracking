using BudgetTracking.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracking.Db.Extensions;

public static class ServiceCollectionExtension
{
   public static IServiceCollection AddDbLayer(this IServiceCollection services, IConfigurationManager config)
   {
      var db = config.GetConnectionString("Db");
      services.AddDbContext<AppDbContext>(builder =>
      {
         builder.UseNpgsql(db);
      });

      services.AddScoped<IAppDbContext, AppDbContext>();
      return services;
   }
}

