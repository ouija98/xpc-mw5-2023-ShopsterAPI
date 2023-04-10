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
                Database.Instance.Rating.Add(rating);
            }

            Database.Instance.Commodity.Add(entity);

            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc/>
        public IEnumerable<CommodityEntity> GetAll()
        {
            return Database.Instance.Commodity.ToList();
        }
        
        /// <inheritdoc/>
        public CommodityEntity GetById(Guid id)
        {
            return Database.Instance.Commodity.Single(s => s.Id == id);
        }   

        /// <inheritdoc/>
        public CommodityEntity Update(CommodityEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCommodity = Database.Instance.Commodity.Single(s => s.Id == entity.Id);

            existingCommodity.Name = entity.Name;
            existingCommodity.Description = entity.Description;
            existingCommodity.Price = entity.Price;
            existingCommodity.Weight = entity.Weight;
            existingCommodity.Quantity = entity.Quantity;
            existingCommodity.CategoryId = entity.CategoryId;
            existingCommodity.ManufacturerId = entity.ManufacturerId;

            // remove old ratings that are not present in the updated commodity
            foreach (var oldRating in existingCommodity.Ratings.ToList())
            {
                if (!entity.Ratings.Contains(oldRating))
                {
                    existingCommodity.Ratings.Remove(oldRating);
                    Database.Instance.Rating.Remove(oldRating);
                }
            }

            // add new ratings that are not present in the existing commodity
            foreach (var newRating in entity.Ratings)
            {
                if (!existingCommodity.Ratings.Contains(newRating))
                {
                    newRating.Id = Guid.NewGuid();
                    existingCommodity.Ratings.Add(newRating);
                    Database.Instance.Rating.Add(newRating);
                }
            }

            Database.Instance.SaveChanges();

            return existingCommodity;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var commodity = Database.Instance.Commodity.Single(s => s.Id == id);
            foreach (var rating in commodity.Ratings)
            {
                Database.Instance.Rating.Remove(rating);
            }
            Database.Instance.Commodity.Remove(commodity);

            Database.Instance.SaveChanges();
        }
    }
}