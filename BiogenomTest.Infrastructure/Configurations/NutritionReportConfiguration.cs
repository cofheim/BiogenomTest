using BiogenomTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class NutritionReportConfiguration : IEntityTypeConfiguration<NutritionReport>
{
    public void Configure(EntityTypeBuilder<NutritionReport> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.CurrentIntake)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.RecommendedSupplements)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Advantages)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
} 