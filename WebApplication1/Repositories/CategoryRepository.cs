using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository for managing categories.
    /// </summary>
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        /// <inheritdoc/>
        public Guid Create(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            Database.Instance.Category.Add(entity);
            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc/>
        public CategoryEntity GetById(Guid id)
        {
            return Database.Instance.Category.Single(c => c.Id == id);
        }

        /// <inheritdoc/>
        public CategoryEntity Update(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCategory = Database.Instance.Category.Single(c => c.Id == entity.Id);
            existingCategory.Name = entity.Name;
            //existingCategory.Commodities = entity.Commodities;
            Database.Instance.SaveChanges();

            return existingCategory;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var category = Database.Instance.Category.Single(c => c.Id == id);
            Database.Instance.Category.Remove(category);
            Database.Instance.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<CategoryEntity> GetAll()
        {
            return Database.Instance.Category;
        }

        /// <summary>
        /// Adds a commodity to a category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to add the commodity to.</param>
        /// <param name="commodity">The commodity to add.</param>
        public void AddCommodity(Guid categoryId, CommodityEntity commodity)
        {
            var category = GetById(categoryId);
            category.Commodities.Add(commodity);
            Database.Instance.SaveChanges();
        }

        /// <summary>
        /// Removes a commodity from a category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to remove the commodity from.</param>
        /// <param name="commodity">The commodity to remove.</param>
        /// <returns>True if the commodity was removed, false otherwise.</returns>
        public bool RemoveCommodity(Guid categoryId, CommodityEntity commodity)
        {
            var category = GetById(categoryId);
            return category.Commodities.Remove(commodity);
        }
    }
}