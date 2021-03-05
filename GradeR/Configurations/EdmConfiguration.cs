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
                .AddCourse();

            return builder.GetEdmModel();
        }

        private static ODataConventionModelBuilder AddCourse(this ODataConventionModelBuilder builder)
        {
            builder.EntitySet<CourseGradeResponseModel>("Course");
            return builder;
        }
    }
}
