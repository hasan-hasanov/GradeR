using DAL;
using DAL.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.DIConfiguration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<GradeRContext>(x => x.UseSqlServer(@"Data Source=.;Initial Catalog=GradeR;User Id=SA; Password=lAKB8oJgz8oFSa43ENSY5dMOAxbg1O"));

            serviceCollection.AddScoped<GetAllStudetsQuery>();
            serviceCollection.AddScoped<StudentService>();

            return serviceCollection;
        }
    }
}
