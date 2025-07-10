using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class SupplementConfiguration : IEntityTypeConfiguration<SupplementEntity>
{
    public void Configure(EntityTypeBuilder<SupplementEntity> builder)
    {
        builder.ToTable("Supplements");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
        builder.Property(s => s.Description).IsRequired(false).HasMaxLength(500);
    }
} 