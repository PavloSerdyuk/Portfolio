using CVService_Koval.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CVService_Koval.DbConnection
{
    public class KPZContext: DbContext
    {
        public KPZContext(DbContextOptions options)
   : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Technologie> Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();
            modelBuilder.Entity<User>()
               .HasIndex(u => u.UserName)
               .IsUnique();
        }
    }

    public class KPZContextFactory : IDesignTimeDbContextFactory<KPZContext>
    {
        public KPZContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KPZContext>();
            optionsBuilder.UseSqlServer("server=PAVLO;Initial Catalog=KPZDb;trusted_connection=true;");

            return new KPZContext(optionsBuilder.Options);
        }
    }
}
