using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;

namespace Shopster.DAL
{
    public class AppDbContext : DbContext
    {
        
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CommodityEntity> Commodity { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ManufacturerEntity> Manufacturer { get; set; }
        public DbSet<RatingEntity> Rating { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<CategoryEntity>()
                .HasMany(c => c.Commodities)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CommodityEntity>()
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.Commodities)
                .HasForeignKey(c => c.ManufacturerId);

            modelBuilder.Entity<CommodityEntity>()
                .HasMany(c => c.Ratings)
                .WithOne(r => r.Commodity)
                .HasForeignKey(r => r.CommodityEntityId);

            modelBuilder.Entity<CommodityEntity>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            DbSeeds.SeedDatabase(modelBuilder);
        }
    }
}