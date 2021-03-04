using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();

            builder.HasOne(x => x.Rank);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Teacher);

            builder.HasMany(x => x.Grades)
                .WithOne(x => x.Teacher);
        }
    }
}
