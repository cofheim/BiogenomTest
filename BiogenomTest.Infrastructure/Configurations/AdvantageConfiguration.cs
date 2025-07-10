using BiogenomTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Configurations;

public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
{
    public void Configure(EntityTypeBuilder<Advantage> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Text).IsRequired().HasMaxLength(300);
    }
} 