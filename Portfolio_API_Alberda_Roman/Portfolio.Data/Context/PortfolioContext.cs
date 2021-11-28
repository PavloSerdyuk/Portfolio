using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Entities;
using Portfolio.Data.EntityConfigurations;
using Portfolio.Data.SeedData;

namespace Portfolio.Data.Context
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Representation> Representations { get; set; }
        public DbSet<User> Users { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RepresentationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Seed();
        }
    }
}
