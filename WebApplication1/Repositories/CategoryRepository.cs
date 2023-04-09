using projekt.Entities;
using projekt.Repositories;

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
            Database.Instance.Categories.Add(entity);

            return entity.Id;
        }

        /// <inheritdoc/>
        public CategoryEntity GetById(Guid id)
        {
            return Database.Instance.Categories.Single(c => c.Id == id);
        }

        /// <inheritdoc/>
        public CategoryEntity Update(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCategory = Database.Instance.Categories.Single(c => c.Id == entity.Id);
            existingCategory.Title = entity.Title;
            existingCategory.Commodities = entity.Commodities;

            return existingCategory;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var category = Database.Instance.Categories.Single(c => c.Id == id);

            if (category.Commodities != null)
            {
                foreach (var commodity in category.Commodities)
                {
                    commodity.Category = null;
                }
            }

            Database.Instance.Categories.Remove(category);
        }

        /// <inheritdoc/>
        public IEnumerable<CategoryEntity> GetAll()
        {
            return Database.Instance.Categories;
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
            commodity.Category = category;
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
            commodity.Category = null;
            return category.Commodities.Remove(commodity);
        }
    }
}
