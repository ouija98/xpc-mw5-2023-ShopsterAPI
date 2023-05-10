using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories.Interfaces;

namespace Shopster.DAL.Repositories
{
    public class CommodityRepository : ICommodityRepository
    {
        private readonly AppDbContext _context;

        public CommodityRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CommodityEntity> GetAll()
        {
            return _context.Commodity
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Include(c => c.Ratings).ToList();
        }

        public Guid Create(CommodityEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Ratings != null)
                foreach (var rating in entity.Ratings)
                {
                    _context.Rating.Add(rating);
                }

            _context.Commodity.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public CommodityEntity? GetById(Guid id)
        {
            return _context.Commodity
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Include(c => c.Ratings).ToList()
                .SingleOrDefault(s => s.Id == id);

        }

        public CommodityEntity Update(CommodityEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCommodity = _context.Commodity.SingleOrDefault(s => s.Id == entity.Id);
            if (existingCommodity == null)
            {
                throw new ArgumentException($"Commodity with id {entity.Id} does not exist.");

            }

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
                    _context.Rating.Remove(oldRating);
                }
            }

            // add new ratings that are not present in the existing commodity
            foreach (var newRating in entity.Ratings)
            {
                if (!existingCommodity.Ratings.Contains(newRating))
                {
                    newRating.Id = Guid.NewGuid();
                    existingCommodity.Ratings.Add(newRating);
                    _context.Rating.Add(newRating);
                }
            }

            _context.SaveChanges();

            return existingCommodity;
        }

        public void Delete(Guid id)
        {
            var commodity = _context.Commodity.Single(s => s.Id == id);
            foreach (var rating in commodity.Ratings)
            {
                _context.Rating.Remove(rating);
            }

            _context.Commodity.Remove(commodity);
            _context.SaveChanges();
        }

        public IEnumerable<CommodityEntity> Search(string? name, decimal? minPrice, decimal? maxPrice, Guid? categoryId,
            int? minRating)
        {
            var commodities = GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                commodities = commodities.Where(c => c.Name.Contains(name!));
            }

            if (minPrice.HasValue)
            {
                commodities = commodities.Where(c => c.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                commodities = commodities.Where(c => c.Price <= maxPrice);
            }

            if (categoryId.HasValue)
            {
                commodities = commodities.Where(c => c.CategoryId == categoryId);
            }

            if (minRating.HasValue)
            {
                commodities = commodities.Where(c => c.Ratings != null && c.Ratings.Any(r => r.Stars >= minRating));
            }

            return commodities;
        }


    }
}