using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Data.Config;

public class StandartConfiguration : IEntityTypeConfiguration<Standart>
{
    public void Configure(EntityTypeBuilder<Standart> builder)
    {
        builder.ToTable("Standart");

        builder.HasKey(s => s.StandartId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
