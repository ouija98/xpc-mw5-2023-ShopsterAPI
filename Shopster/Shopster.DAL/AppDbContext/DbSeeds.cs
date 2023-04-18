using Microsoft.EntityFrameworkCore;
using Shopster.Entities;

namespace Shopster.Shopster.DAL.AppDbContext
{
    public static class DbSeeds
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {

            var categoryData = new List<CategoryEntity>()
            {
                new CategoryEntity() { Id = Guid.NewGuid(), Name = "ctg1" },
                new CategoryEntity() { Id = Guid.NewGuid(), Name = "ctg3" },
                new CategoryEntity() { Id = Guid.NewGuid(), Name = "ctg5" },
                new CategoryEntity() { Id = Guid.NewGuid(), Name = "ctg6" },
            };

            modelBuilder.Entity<CategoryEntity>().HasData(categoryData);


            var manufacturerData = new List<ManufacturerEntity>()
            {
                new ManufacturerEntity() { Id = Guid.NewGuid(), Name = "manu1" , 
                    Description = "desc1" , Logo = "logo1.png" , CountryOfOrigin = "CZ"  },
                new ManufacturerEntity() { Id = Guid.NewGuid(), Name = "manu2" ,
                    Description = "desc2" , Logo = "logo2.png" , CountryOfOrigin = "CZ"  },
                new ManufacturerEntity() { Id = Guid.NewGuid(), Name = "manu3" ,
                    Description = "desc3" , Logo = "logo3.png" , CountryOfOrigin = "CZ"  },
                new ManufacturerEntity() { Id = Guid.NewGuid(), Name = "manu4" ,
                    Description = "desc4" , Logo = "logo4.png" , CountryOfOrigin = "CZ"  },
            };

            modelBuilder.Entity<ManufacturerEntity>().HasData(manufacturerData);

            
            var commodityData = new List<CommodityEntity>()
            {
                new CommodityEntity() { Id = Guid.NewGuid(), Name = "cmd1"  ,
                Picture = "picture.jpg" , Description = "desc1" , Price = 10 ,
                Weight = 20 , Quantity = 2 , CategoryId = categoryData[0].Id ,
                ManufacturerId = manufacturerData[2].Id },
                new CommodityEntity() { Id = Guid.NewGuid(), Name = "cmd2"  ,
                Picture = "picture.jpg" , Description = "desc2" , Price = 1 ,
                Weight = 5 , Quantity = 2 , CategoryId = categoryData[1].Id ,
                ManufacturerId = manufacturerData[1].Id },
                new CommodityEntity() { Id = Guid.NewGuid(), Name = "cmd3"  ,
                Picture = "picture.jpg" , Description = "desc3" , Price = 23254 ,
                Weight = 15 , Quantity = 20 , CategoryId = categoryData[3].Id ,
                ManufacturerId = manufacturerData[2].Id },
                new CommodityEntity() { Id = Guid.NewGuid(), Name = "cmd4"  ,
                Picture = "picture.jpg" , Description = "desc4" , Price = 55 ,
                Weight = 15 , Quantity = 10 , CategoryId = categoryData[3].Id ,
                ManufacturerId = manufacturerData[3].Id },
            };

            modelBuilder.Entity<CommodityEntity>().HasData(commodityData);
            

            
            var ratingData = new List<RatingEntity>()
            {
                new RatingEntity() { Id = Guid.NewGuid(), Stars = 1 ,
                    Title = "title1" , Description = "desc1" , CommodityEntityId = commodityData[1].Id  },
                new RatingEntity() { Id = Guid.NewGuid(), Stars = 5 ,
                    Title = "title2" , Description = "desc2" , CommodityEntityId = commodityData[1].Id  },
                new RatingEntity() { Id = Guid.NewGuid(), Stars = 5 ,
                    Title = "title3" , Description = "desc3" , CommodityEntityId = commodityData[3].Id  },
                new RatingEntity() { Id = Guid.NewGuid(), Stars = 4 ,
                    Title = "title4" , Description = "desc4" , CommodityEntityId = commodityData[0].Id  },
            };
            
            modelBuilder.Entity<RatingEntity>().HasData(ratingData);

   

        }
    }
}
