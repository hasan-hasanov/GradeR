using Core.Entities;
using Core.Queries;
using DAL;
using DAL.Queries.GetAllStudents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Services.DIConfiguration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(
            this IServiceCollection serviceCollection)
        {
            // TODO: Move this to config file
            serviceCollection.AddDbContext<GradeRContext>(x => x.UseSqlServer(@"Data Source=.;Initial Catalog=GradeR;User Id=SA; Password=lAKB8oJgz8oFSa43ENSY5dMOAxbg1O"));

            // Queries
            serviceCollection.AddScoped<IQueryHandler<GetAllStudentsQuery, IList<Student>>, GetAllStudentsQueryHandler>();

            // TODO: Clear these gradually and replace them with better patterns
            serviceCollection.AddScoped<StudentService>();

            return serviceCollection;
        }
    }
}
