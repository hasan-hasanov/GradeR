using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StudentGrade).IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
