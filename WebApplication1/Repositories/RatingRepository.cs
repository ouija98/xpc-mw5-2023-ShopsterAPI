using projekt;
using projekt.Entities;
using projekt.Repositories;

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
            Database.Instance.Ratings.Add(entity);
            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc />
        public RatingEntity GetById(Guid id)
        {
            return Database.Instance.Ratings.Single(r => r.Id == id);
        }

        /// <inheritdoc />
        public RatingEntity Update(RatingEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingRating = Database.Instance.Ratings.Single(r => r.Id == entity.Id);
            existingRating.Stars = entity.Stars;
            existingRating.Title = entity.Title;
            existingRating.Description = entity.Description;

            return existingRating;
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            var rating = Database.Instance.Ratings.Single(r => r.Id == id);
            Database.Instance.Ratings.Remove(rating);
        }

        /// <inheritdoc />
        public IEnumerable<RatingEntity> GetAll()
        {
            return Database.Instance.Ratings;
        }
    }
}
