using MediatR;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Services.DIConfiguration;
using Services.Models.ResponseModels;

namespace GradeR.Configurations
{
    public class AppConfiguration
    {
        public static void AddMvcCore(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.EnableEndpointRouting = false;
            })
            .AddApiExplorer()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public static void AddDependencies(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.RegisterTypes(configuration);
        }

        public static void AddMediatr(IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolver).Assembly);
        }

        public static void AddOdata(IServiceCollection services)
        {
            services.AddOData();
        }

        public static void UseHttpsRedirection(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
        }

        public static void UseRouting(IApplicationBuilder app)
        {
            app.UseRouting();
        }

        public static void UseMvc(IApplicationBuilder app)
        {
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<CourseGradeResponseModel>("Course");
            return builder.GetEdmModel();
        }
    }
}
