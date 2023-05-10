using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories.Interfaces;

namespace Shopster.DAL.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public Guid Create(RatingEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            _context.Rating.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public RatingEntity? GetById(Guid id)
        {
            return _context.Rating
                .Include(r => r.Commodity)
                .SingleOrDefault(r => r.Id == id);
        }

        public RatingEntity Update(RatingEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingRating = _context.Rating.SingleOrDefault(r => r.Id == entity.Id);
            if (existingRating == null)
            {
                throw new ArgumentException($"Commodity with id {entity.Id} does not exist.");
            }
            existingRating.Stars = entity.Stars;
            existingRating.Title = entity.Title;
            existingRating.Description = entity.Description;

            _context.SaveChanges();
            return existingRating;
        }

        public void Delete(Guid id)
        {
            var rating = _context.Rating.Single(r => r.Id == id);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
                _context.SaveChanges();
            }
        }

        public IEnumerable<RatingEntity> GetAll()
        {
            return _context.Rating
                .Include(r => r.Commodity);
        }
        
        public IEnumerable<RatingEntity> GetRatingsByCommodityId(Guid commodityId)
        {
            return _context.Rating.Where(r => r.CommodityEntityId == commodityId).ToList();
        }
        
    }
}