using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Api.Domain.Config
{
    public static class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            Repository.Config.Configuration.Configure(services, configuration);
            var assemblyService = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Api.Domain")
                 .FirstOrDefault();
            var serviceList = assemblyService.GetTypes()
                .Where(x => x.Name.EndsWith("Service") && !x.Name.StartsWith("I"));

            foreach (var service in serviceList)
            {
                var nameService = service.Name;
                var iService = assemblyService.GetTypes().Where(a => a.Name == "I" + nameService).FirstOrDefault();
                if (iService != null)
                {
                    services.AddScoped(iService, service);
                }
            }
        }

        public static void ConfigureApp(IApplicationBuilder app)
        {
            Repository.Config.Configuration.ConfigureApp(app);
        }
    }
}
