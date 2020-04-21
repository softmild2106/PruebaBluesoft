using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Api.Repository.Config
{
    public static class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            Database.Config.Configuration.ConfigDataBase(services, configuration);

            //Config DependencieInjection
            var assemblyRepo = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Api.Repository")
                .FirstOrDefault();
            var repositoryList = assemblyRepo.GetTypes()
                .Where(x => x.Name.EndsWith("Repository") && !x.Name.StartsWith("I"));

            foreach (var repository in repositoryList)
            {
                var nameRepository = repository.Name;
                var iRepository = assemblyRepo.GetTypes().Where(a => a.Name == "I" + nameRepository).FirstOrDefault();
                if (iRepository != null)
                {
                    services.AddScoped(iRepository, repository);
                }
            }
        }

        public static void ConfigureApp(IApplicationBuilder app)
        {
            Database.Config.Configuration.DatabaseMigrate(app);
        }



    }
}
