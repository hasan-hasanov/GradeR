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

        public GradeRContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentTeacherCourse> StudentTeacherCourses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public GradeRContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GradeRContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=GradeR;User Id=SA; Password=lAKB8oJgz8oFSa43ENSY5dMOAxbg1O");

            return new GradeRContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new GradeConfig());
            modelBuilder.ApplyConfiguration(new RankConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new StudentTeacherCourseConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
        }
    }
}
