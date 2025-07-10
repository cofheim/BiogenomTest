using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class NutritionReportConfiguration : IEntityTypeConfiguration<NutritionReportEntity>
{
    public void Configure(EntityTypeBuilder<NutritionReportEntity> builder)
    {
        builder.ToTable("NutritionReports");
        builder.HasKey(r => r.Id);

        //  связь один к многим: один отчет содержит много записей о текущем потреблении
        builder.HasMany(r => r.CurrentIntake)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade); // при удалении отчета удаляются и все связанные с ним записи о потреблении

        // связь один к многим: один отчет содержит много рекомендованных БАД
        builder.HasMany(r => r.RecommendedSupplements)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        // связь один к многим: один отчет содержит много преимуществ
        builder.HasMany(r => r.Advantages)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
} 