using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Services.Models.CourseModels.ResponseModels;
using Services.Models.GradeModels.ResponseModels;
using Services.Models.StudentModels.ResponseModels;

namespace GradeR.Configurations
{
    public static class EdmConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder()
                .AddCourse()
                .AddStudents()
                .AddGrade();

            return builder.GetEdmModel();
        }

        private static ODataConventionModelBuilder AddCourse(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<CourseResponseModel>("Course");
            builder.ComplexType<CourseTeacherResponseModel>();

            return builder;
        }

        private static ODataConventionModelBuilder AddStudents(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<StudentResponseModel>("Student");
            builder.ComplexType<StudentGradeResponseModel>();
            builder.ComplexType<StudentCourseResponseModel>();

            return builder;
        }

        private static ODataConventionModelBuilder AddGrade(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<GradeResponseModel>("Grade");

            return builder;
        }
    }
}
