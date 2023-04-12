using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    /// <inheritdoc />
    public class RatingRepository : IRepository<RatingEntity>
    {
        /// <inheritdoc />
        public Guid Create(RatingEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            Database.Instance.Rating.Add(entity);
            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc />
        public RatingEntity GetById(Guid id)
        {
            return Database.Instance.Rating.Single(r => r.Id == id);
        }

        /// <inheritdoc />
        public RatingEntity Update(RatingEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingRating = Database.Instance.Rating.Single(r => r.Id == entity.Id);
            existingRating.Stars = entity.Stars;
            existingRating.Title = entity.Title;
            existingRating.Description = entity.Description;

            Database.Instance.SaveChanges();
            return existingRating;
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            var rating = Database.Instance.Rating.Single(r => r.Id == id);
            Database.Instance.Rating.Remove(rating);
            Database.Instance.SaveChanges();
        }

        /// <inheritdoc />
        public IEnumerable<RatingEntity> GetAll()
        {
            return Database.Instance.Rating;
        }
    }
}