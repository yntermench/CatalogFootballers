using CatalogFootballers.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogFootballers.Data
{
    /// <summary>
    /// The class responsible for configuring the database.
    /// </summary>
    public class CatalogFootballersDbContext : DbContext
    {
        public virtual DbSet<Footballer> Footballers { get; set; }
        public virtual DbSet<TitleCommand> TitlesCommands { get; set; }
        public CatalogFootballersDbContext(DbContextOptions<CatalogFootballersDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureIndexes(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetupAuditTrail();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetupAuditTrail();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetupAuditTrail()
        {
            var dtNow = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is EntityBase)
                {
                    var entity = entry.Entity as EntityBase;
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = entity.UpdatedDate = dtNow;
                    }
                    else if(entry.State == EntityState.Modified)
                    {
                        entity.UpdatedDate = dtNow;
                    }
                }
            }
        }
        /// <summary>
        /// Configure indexes Database <see cref="CatalogFootballersDbContext"/>. 
        /// </summary>
        /// <param name="builder"></param>
        private static void ConfigureIndexes(ModelBuilder builder)
        {
            builder.Entity<TitleCommand>()
                .HasIndex(tc => tc.Title)
                .IsUnique();
        }
    }
}
