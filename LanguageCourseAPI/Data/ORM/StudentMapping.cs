using LanguageCourseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LanguageCourseAPI.Data.ORM
{
    public class StudentMapping: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //defines the relational ClassRoom(turma) => Students(estudantes) of hasOne WithMany
            //the relationship is mandatory, so each one student needs having a classRoom associated            
            builder.HasOne(cr => cr.ClassRoom).WithMany(std => std.Students).IsRequired();
            

        }
    }
}
