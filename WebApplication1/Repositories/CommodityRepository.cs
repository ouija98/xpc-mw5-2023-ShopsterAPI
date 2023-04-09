using System;
using System.Collections.Generic;
using System.Linq;
using projekt.Entities;
using projekt.Repositories;

namespace WebApplication1.Repositories
{
    public class CommodityRepository : IRepository<CommodityEntity>
    {
        /// <inheritdoc/>
        public Guid Create(CommodityEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();

            foreach (var rating in entity.Ratings)
            {
                rating.Id = Guid.NewGuid();
                Database.Instance.Ratings.Add(rating);
            }

            Database.Instance.Commodities.Add(entity);

            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc/>
        public IEnumerable<CommodityEntity> GetAll()
        {
            return Database.Instance.Commodities.ToList();
        }
        
        /// <inheritdoc/>
        public CommodityEntity GetById(Guid id)
        {
            return Database.Instance.Commodities.Single(s => s.Id == id);
        }   

        /// <inheritdoc/>
        public CommodityEntity Update(CommodityEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCommodity = Database.Instance.Commodities.Single(s => s.Id == entity.Id);

            existingCommodity.Name = entity.Name;
            existingCommodity.Description = entity.Description;
            existingCommodity.Price = entity.Price;
            existingCommodity.Weight = entity.Weight;
            existingCommodity.Quantity = entity.Quantity;
            existingCommodity.Category = entity.Category;
            existingCommodity.Manufacturer = entity.Manufacturer;

            // remove old ratings that are not present in the updated commodity
            foreach (var oldRating in existingCommodity.Ratings.ToList())
            {
                if (!entity.Ratings.Contains(oldRating))
                {
                    existingCommodity.Ratings.Remove(oldRating);
                    Database.Instance.Ratings.Remove(oldRating);
                }
            }

            // add new ratings that are not present in the existing commodity
            foreach (var newRating in entity.Ratings)
            {
                if (!existingCommodity.Ratings.Contains(newRating))
                {
                    newRating.Id = Guid.NewGuid();
                    existingCommodity.Ratings.Add(newRating);
                    Database.Instance.Ratings.Add(newRating);
                }
            }

            Database.Instance.SaveChanges();

            return existingCommodity;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var commodity = Database.Instance.Commodities.Single(s => s.Id == id);
            foreach (var rating in commodity.Ratings)
            {
                Database.Instance.Ratings.Remove(rating);
            }
            Database.Instance.Commodities.Remove(commodity);

            Database.Instance.SaveChanges();
        }
    }
}
