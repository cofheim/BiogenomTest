using BiogenomTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Infrastructure;

public class BiogenomTestDbContext : DbContext
{
    public DbSet<NutritionReport> NutritionReports { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<Supplement> Supplements { get; set; }
    public DbSet<Advantage> Advantages { get; set; }

    public BiogenomTestDbContext(DbContextOptions<BiogenomTestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BiogenomTestDbContext).Assembly);
    }
}
