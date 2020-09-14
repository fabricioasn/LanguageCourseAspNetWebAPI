using Microsoft.EntityFrameworkCore;
using LanguageCourseAPI.Models;
using LanguageCourseAPI.Data.ORM;

namespace LanguageCourseAPI.Data
{
    public class DataContextAPI : DbContext
    {
        //Data context for DDD Codefirst development paradigm database creation and updating 
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseSqlServer(@"Server=localhost,1433;Database=dbo.CursoDeIdiomas;User ID=sa;Password=root");
        }

        //applies the ORM relationship configuration in migration time for db Creation
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentMapping());
            
            //on creation defines enrollment as unique
            builder.Entity<Student>()
            .HasIndex(s => s.Enrollment)
            .IsUnique();

        }

        //constructor of dataContext used by the addDataContex to load a DTO in SQLSERVER
        public DataContextAPI(DbContextOptions<DataContextAPI> opts) : base(opts)
        { }

    }
}
