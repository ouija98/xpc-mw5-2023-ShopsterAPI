using projekt.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        private Database()
        {
            // Private constructor to prevent instantiation from outside the class.
        }

        public DbSet<CommodityEntity> Commodities { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string_here");
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
                .HasForeignKey(c => c.Category.Id);

            modelBuilder.Entity<CommodityEntity>()
                .HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey(c => c.Manufacturer.Id);
        }
    }
}