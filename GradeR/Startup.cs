using GradeR.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GradeR
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup()
        {
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.Development.json", optional: true)
               .AddJsonFile("appSettings.json", optional: true)
               .AddEnvironmentVariables()
               .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppConfiguration.AddDependencies(services, _configuration);
            AppConfiguration.AddMvcCore(services);
            AppConfiguration.AddMediatr(services);
            AppConfiguration.AddOdata(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            AppConfiguration.UseHttpsRedirection(app);
            AppConfiguration.UseRouting(app);
#pragma warning disable MVC1005 // Cannot use UseMvc with Endpoint Routing.
            AppConfiguration.UseMvc(app);
#pragma warning restore MVC1005 // Cannot use UseMvc with Endpoint Routing.
        }
    }
}
