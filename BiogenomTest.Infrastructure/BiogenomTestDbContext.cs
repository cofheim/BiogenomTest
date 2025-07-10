using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Infrastructure
{
    public class BiogenomTestDbContext : DbContext
    {
        public BiogenomTestDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
