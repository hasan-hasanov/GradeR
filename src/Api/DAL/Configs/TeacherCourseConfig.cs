using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class TeacherCourseConfig : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Teachers)
                .HasForeignKey(t => t.CourseId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Courses)
                .HasForeignKey(t => t.TeacherId);
        }
    }
}
