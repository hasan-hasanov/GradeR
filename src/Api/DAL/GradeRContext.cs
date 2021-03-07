using Core.Entities;
using DAL.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class GradeRContext : DbContext, IDesignTimeDbContextFactory<GradeRContext>
    {
        public GradeRContext()
        {
        }

        public GradeRContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<StudentCourse> TeacherCourses { get; set; }

        public GradeRContext CreateDbContext(string[] args)
        {
            // TODO: Move this to proper location
            var optionsBuilder = new DbContextOptionsBuilder<GradeRContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=GradeR;Trusted_Connection=False;User Id=SA; Password=lAKB8oJgz8oFSa43ENSY5dMOAxbg1O;MultipleActiveResultSets=true");

            return new GradeRContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new GradeConfig());
            modelBuilder.ApplyConfiguration(new RankConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new StudentCourseConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
        }
    }
}
