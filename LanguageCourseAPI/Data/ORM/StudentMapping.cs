using LanguageCourseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//ORM class for types and relationship mapping of student

namespace LanguageCourseAPI.Data.ORM
{
    public class StudentMapping: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //defines the relational ClassRoom(turma) => Students(estudantes) of hasOne WithMany
            //the relationship is mandatory, so each one student needs having a classRoom associated            
            builder.HasOne(cr => cr.ClassRoom).WithMany(std => std.Students).IsRequired();
            //mapping the datatypes to .net for sql to boost db performance by tunning Inmemory Usage
            builder.Property(fn => fn.FullName).IsRequired().HasColumnType("varchar(120)");
            builder.Property(c => c.CPF).IsRequired().HasColumnType("char(11)");
            builder.Property(r => r.RG).HasColumnType("char(9)");
            builder.Property(e => e.Enrollment).IsRequired().HasColumnType("char(10)");
            builder.Property(a => a.Address).HasColumnType("varchar(150)");
            builder.Property(p => p.Phone).HasColumnType("char(9)");
            builder.Property(b => b.BirthDate).IsRequired().HasColumnType("Date");



        }
    }
}
