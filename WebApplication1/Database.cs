using projekt.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Database : DbContext
    {
        private static Database _instance;

        public static Database Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }
                return _instance;
            }
        }
        
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }
        
        private Database()
        {
            // Private constructor to prevent instantiation from outside the class.
        }

        public DbSet<CommodityEntity> Commodity { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ManufacturerEntity> Manufacturer { get; set; }
        public DbSet<RatingEntity> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommodityEntity>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<CategoryEntity>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ManufacturerEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<RatingEntity>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<CommodityEntity>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Commodities)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CommodityEntity>()
                .HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey(c => c.ManufacturerId);
        }
    }
}