using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class SupplementNutrientConfiguration : IEntityTypeConfiguration<SupplementNutrientEntity>
{
    public void Configure(EntityTypeBuilder<SupplementNutrientEntity> builder)
    {
        builder.ToTable("SupplementNutrients");
        builder.HasKey(sn => sn.Id);
        
        builder.Property(sn => sn.Unit).IsRequired().HasMaxLength(20);

        //  связь один к многим: один Supplement может иметь много записей о составе SupplementNutrient
        builder.HasOne(sn => sn.Supplement)
            .WithMany(s => s.Nutrients) // связь с навигационным свойством Nutrients в SupplementEntity
            .HasForeignKey(sn => sn.SupplementId)
            .OnDelete(DeleteBehavior.Cascade); // при удалении БАД удаляются и все записи о его составе

        //  связь один к многим: один Nutrient может быть в составе многих БАД
        builder.HasOne(sn => sn.Nutrient)
            .WithMany() 
            .HasForeignKey(sn => sn.NutrientId)
            .OnDelete(DeleteBehavior.Cascade); // при удалении нутриента удаляются все записи о нем в составах БАД
    }
} 