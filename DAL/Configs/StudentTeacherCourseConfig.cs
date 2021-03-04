using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class StudentTeacherCourseConfig : IEntityTypeConfiguration<StudentTeacherCourse>
    {
        public void Configure(EntityTypeBuilder<StudentTeacherCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.StudentTeacherCourses);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Courses);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Courses);
        }
    }
}
