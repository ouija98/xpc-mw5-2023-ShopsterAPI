using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;

namespace Shopster.DAL
{
    public static class DbSeeds
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            var categoryData = new List<CategoryEntity>();
            var categoryFaker = new Faker<CategoryEntity>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Name, f => f.Commerce.Department());

            for (int i = 0; i < 4; i++)
            {
                categoryData.Add(categoryFaker.Generate());
            }

            modelBuilder.Entity<CategoryEntity>().HasData(categoryData);


            var manufacturerData = new List<ManufacturerEntity>();
            var manufacturerFaker = new Faker<ManufacturerEntity>()
                .RuleFor(m => m.Id, f => f.Random.Guid())
                .RuleFor(m => m.Name, f => f.Company.CompanyName())
                .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
                .RuleFor(m => m.Logo, f => f.Internet.Avatar())
                .RuleFor(m => m.CountryOfOrigin, f => f.Address.Country());

            for (int i = 0; i < 4; i++)
            {
                manufacturerData.Add(manufacturerFaker.Generate());
            }

            modelBuilder.Entity<ManufacturerEntity>().HasData(manufacturerData);


            var commodityData = new List<CommodityEntity>();
            var commodityFaker = new Faker<CommodityEntity>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Picture, f => f.Image.PicsumUrl())
                .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
                .RuleFor(c => c.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(c => c.Weight, f => f.Random.Float(1, 100))
                .RuleFor(c => c.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(c => c.CategoryId, f => f.PickRandom(categoryData).Id)
                .RuleFor(c => c.ManufacturerId, f => f.PickRandom(manufacturerData).Id);

            for (int i = 0; i < 4; i++)
            {
                commodityData.Add(commodityFaker.Generate());
            }

            modelBuilder.Entity<CommodityEntity>().HasData(commodityData);


            var ratingData = new List<RatingEntity>();
            var ratingFaker = new Faker<RatingEntity>()
                .RuleFor(r => r.Id, f => f.Random.Guid())
                .RuleFor(r => r.Stars, f => f.Random.Int(1, 5))
                .RuleFor(r => r.Title, f => f.Lorem.Sentence())
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.CommodityEntityId, f => f.PickRandom(commodityData).Id);

            for (int i = 0; i < 4; i++)
            {
                ratingData.Add(ratingFaker.Generate());
            }

            modelBuilder.Entity<RatingEntity>().HasData(ratingData);
        }
    }
}
