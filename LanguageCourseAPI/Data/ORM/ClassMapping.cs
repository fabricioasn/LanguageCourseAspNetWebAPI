using LanguageCourseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


//ORM class for types and relationship mapping of classes

namespace LanguageCourseAPI.Data.ORM
{
    public class ClassMapping : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            //mapping the datatypes to .net for sql to boost db performance by tunning Inmemory Usage
            builder.Property(l => l.Language).IsRequired().HasColumnType("varchar(60)");
            builder.Property(m => m.Module).IsRequired().HasColumnType("varchar(20)");
            builder.Property(s => s.Shift).HasColumnType("varchar(60)");
            builder.Property(t => t.TeachingMethodology).IsRequired().HasColumnType("varchar(200)");
        }

    }
}
