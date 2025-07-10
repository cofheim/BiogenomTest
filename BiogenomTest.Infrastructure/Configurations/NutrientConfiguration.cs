using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class NutrientConfiguration : IEntityTypeConfiguration<NutrientEntity>
{
    public void Configure(EntityTypeBuilder<NutrientEntity> builder)
    {
        builder.ToTable("Nutrients");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
        builder.Property(n => n.Unit).IsRequired().HasMaxLength(20);
        builder.Property(n => n.MaxNormalValue).IsRequired(false);
    }
} 