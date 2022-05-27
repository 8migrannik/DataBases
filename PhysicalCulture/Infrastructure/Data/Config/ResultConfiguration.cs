using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Data.Config;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.ToTable("Result");

        builder.HasKey(r => r.ResultId);

        builder.Property(r => r.StudentId)
            .IsRequired();

        builder.Property(r => r.StandartId)
            .IsRequired();
    }
}
