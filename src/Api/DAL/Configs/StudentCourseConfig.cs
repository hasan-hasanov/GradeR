using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
