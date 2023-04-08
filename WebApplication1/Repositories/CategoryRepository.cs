using projekt;
using projekt.Entities;
using projekt.Repositories;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository for managing categories.
    /// </summary>
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="entity">The category to create.</param>
        /// <returns>The ID of the created category.</returns>
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

        /// <summary>
        /// Gets a specific category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to get.</param>
        /// <returns>The category with the specified ID.</returns>
        public CategoryEntity GetById(Guid id)
        {
            return Database.Instance.Categories.Single(c => c.Id == id);
        }

        /// <summary>
        /// Modifies an existing category.
        /// </summary>
        /// <param name="entity">The modified category.</param>
        /// <returns>The modified category.</returns>
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

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
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
