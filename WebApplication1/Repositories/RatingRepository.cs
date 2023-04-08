using projekt.Entities;

namespace projekt.Repositories;
    /// <summary>
    /// The repository for managing <see cref="RatingEntity"/> entities.
    /// </summary>
    public class RatingRepository : IRepository<RatingEntity>
    {
        /// <summary>
        /// Creates a new rating entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="entity"/> is null.</exception>
        public Guid Create(RatingEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            Database.Instance.Ratings.Add(entity);

            return entity.Id;
        }

        /// <summary>
        /// Gets the rating entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the rating entity to get.</param>
        /// <returns>The rating entity with the specified ID.</returns>
        public RatingEntity GetById(Guid id)
        {
            return Database.Instance.Ratings.Single(r => r.Id == id);
        }

        /// <summary>
        /// Updates an existing rating entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated rating entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="entity"/> is null.</exception>
        public RatingEntity Update(RatingEntity? entity)
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

        /// <summary>
        /// Deletes the rating entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the rating entity to delete.</param>
        public void Delete(Guid id)
        {
            var rating = Database.Instance.Ratings.Single(r => r.Id == id);
            Database.Instance.Ratings.Remove(rating);
        }
    }