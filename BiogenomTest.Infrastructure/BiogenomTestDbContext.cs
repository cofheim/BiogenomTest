using BiogenomTest.Infrastructure.Configurations;
using BiogenomTest.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Infrastructure;

public class BiogenomTestDbContext : DbContext
{
    public BiogenomTestDbContext(DbContextOptions<BiogenomTestDbContext> options) : base(options)
    {
    }

    // таблицы
    public DbSet<NutritionReportEntity> NutritionReports { get; set; }
    public DbSet<NutrientEntity> Nutrients { get; set; }
    public DbSet<SupplementEntity> Supplements { get; set; }
    public DbSet<AdvantageEntity> Advantages { get; set; }
    public DbSet<SupplementNutrientEntity> SupplementNutrients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // регистрация

        modelBuilder.ApplyConfiguration(new NutritionReportConfiguration());
        modelBuilder.ApplyConfiguration(new NutrientConfiguration());
        modelBuilder.ApplyConfiguration(new SupplementConfiguration());
        modelBuilder.ApplyConfiguration(new AdvantageConfiguration());
        modelBuilder.ApplyConfiguration(new SupplementNutrientConfiguration());
    }
}
