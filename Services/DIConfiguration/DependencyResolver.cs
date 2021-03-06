using Core.Commands;
using Core.Entities;
using Core.Queries;
using Core.Validation;
using DAL;
using DAL.Commands.EvaluateStudent;
using DAL.Queries.GetAllCourses;
using DAL.Queries.GetAllGrades;
using DAL.Queries.GetAllStudents;
using DAL.Queries.GetCourseById;
using DAL.Queries.GetStudentById;
using DAL.Queries.GetTeacherById;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Models.CourseModels.RequestModels;
using Services.Models.GradeModels.RequestModels;
using Services.Models.StudentModels.RequestModels;
using Services.Validations;
using System.Collections.Generic;

namespace Services.DIConfiguration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            // Add database connection string
            serviceCollection.AddDbContext<GradeRContext>(x => x.UseSqlServer(configuration.GetConnectionString("GradeR")));

            // Add health Checks
            serviceCollection.AddHealthChecks()
                .AddDbContextCheck<GradeRContext>();

            // Queries
            serviceCollection.AddScoped<IQueryHandler<GetAllCoursesQuery, IList<Course>>, GetAllCoursesQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetAllGradesQuery, IList<Grade>>, GetAllGradesQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetAllStudentsQuery, IList<Student>>, GetAllStudentsQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetCourseByIdQuery, Course>, GetCourseByIdQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetStudentByIdQuery, Student>, GetStudentByIdQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetTeacherByIdQuery, Teacher>, GetTeacherByIdQueryHandler>();

            // Commands
            serviceCollection.AddScoped<ICommandHandler<EvaluateStudentCommand>, EvaluateStudentCommandHandler>();

            // Validations
            serviceCollection.AddScoped<IValidation<GetCourseByIdRequestModel>, GetCourseGradeByIdRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<GetStudentByIdRequestModel>, GetStudentByIdRequestModelValidator>();
            serviceCollection.AddScoped<IValidation<PostGradeRequestModel>, PostGradeRequestModelValidator>();

            return serviceCollection;
        }
    }
}
