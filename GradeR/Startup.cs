using Core.Entities;
using GradeR.Controllers;
using GradeR.Filters;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Services.DIConfiguration;

namespace GradeR
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(typeof(GlobalExceptionHandlingFilter));
                options.EnableEndpointRouting = false;
            })
            .AddApiExplorer()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOData();
            services.RegisterTypes();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Grade");
            return builder.GetEdmModel();
        }
    }
}
