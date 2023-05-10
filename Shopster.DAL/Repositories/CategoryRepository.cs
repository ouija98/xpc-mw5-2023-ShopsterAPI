using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories.Interfaces;

namespace Shopster.DAL.Repositories
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryEntity> Get()
        {
            return _context.Category
                .Include(c => c.Commodities);
        }
        
        public Guid Create(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Category.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public CategoryEntity? GetById(Guid id)
        {
            return _context.Category
                .Include(c => c.Commodities)
                .SingleOrDefault(c => c.Id == id);
        }

        public CategoryEntity Update(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCategory = _context.Category.SingleOrDefault(c => c.Id == entity.Id);
            if (existingCategory == null)
            {
                throw new ArgumentException($"Category with id {entity.Id} does not exist.");

            }

            existingCategory.Name = entity.Name;
            existingCategory.Commodities = entity.Commodities;
            _context.SaveChanges();

            return existingCategory;
        }

        public void Delete(Guid id)
        {
            var category = _context.Category.Single(c => c.Id == id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}