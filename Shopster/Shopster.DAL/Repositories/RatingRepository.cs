using Shopster.Entities;

namespace Shopster.Shopster.DAL.Repositories
{
    public class RatingRepository : IRepository<RatingEntity>
    {
        private readonly AppDbContext.AppDbContext _context;

        public RatingRepository(AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        public Guid Create(RatingEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            _context.Rating.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public RatingEntity GetById(Guid id)
        {
            return _context.Rating.Single(r => r.Id == id);
        }

        public RatingEntity Update(RatingEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingRating = _context.Rating.Single(r => r.Id == entity.Id);
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
            return _context.Rating.ToList();
        }
    }
}