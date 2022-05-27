using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Data.Config;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");

        builder.HasKey(s => s.StudentId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
