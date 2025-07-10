using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class AdvantageConfiguration : IEntityTypeConfiguration<AdvantageEntity>
{
    public void Configure(EntityTypeBuilder<AdvantageEntity> builder)
    {
        // Указываем, что сущность будет сопоставлена с таблицей "Advantages"
        builder.ToTable("Advantages");
        // Определяем первичный ключ
        builder.HasKey(a => a.Id);

        // Устанавливаем, что свойство Text является обязательным и имеет максимальную длину 300
        builder.Property(a => a.Text).IsRequired().HasMaxLength(300);
    }
} 