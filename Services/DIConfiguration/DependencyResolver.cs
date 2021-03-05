﻿using Core.Commands;
using Core.Entities;
using Core.Queries;
using DAL;
using DAL.Commands.EvaluateStudent;
using DAL.Queries.GetAllCourses;
using DAL.Queries.GetAllStudents;
using DAL.Queries.GetCourseById;
using DAL.Queries.GetStudentById;
using DAL.Queries.GetTeacherById;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            serviceCollection.AddScoped<IQueryHandler<GetAllStudentsQuery, IList<Student>>, GetAllStudentsQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetCourseByIdQuery, Course>, GetCourseByIdQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetStudentByIdQuery, Student>, GetStudentByIdQueryHandler>();
            serviceCollection.AddScoped<IQueryHandler<GetTeacherByIdQuery, Teacher>, GetTeacherByIdQueryHandler>();

            // Commands
            serviceCollection.AddScoped<ICommandHandler<EvaluateStudentCommand>, EvaluateStudentCommandHandler>();

            return serviceCollection;
        }
    }
}
