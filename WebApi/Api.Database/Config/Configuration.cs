using Api.Database.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Database.Config
{
    public static class Configuration
    {
        public static void ConfigDataBase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
          
        }

        public static void DatabaseMigrate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
                context.Database.Migrate();
            }
        }
    }
}
