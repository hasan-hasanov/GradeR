using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Services.Models.ResponseModels;

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
            builder.EntitySet<CourseGradeResponseModel>("Course");
            builder.ComplexType<GradeResponseModel>();
            builder.ComplexType<TeacherResponseModel>();

            return builder;
        }

        private static ODataConventionModelBuilder AddStudents(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<StudentResponseModel>("Student");
            builder.ComplexType<StudentGradeResponseModel>();

            return builder;
        }

        private static ODataConventionModelBuilder AddGrade(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<StudentResponseModel>("Grade");

            return builder;
        }
    }
}
