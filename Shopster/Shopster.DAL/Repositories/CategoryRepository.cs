using Microsoft.EntityFrameworkCore;
using Shopster.Entities;

namespace Shopster.Shopster.DAL.Repositories
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        private readonly AppDbContext.AppDbContext _context;

        public CategoryRepository(AppDbContext.AppDbContext context)
        {
            _context = context;
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

        public CategoryEntity GetById(Guid id)
        {
            return _context.Category
                .Include(c => c.Commodities)
                .Single(c => c.Id == id);
        }
        
        public CategoryEntity Update(CategoryEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCategory = _context.Category.Single(c => c.Id == entity.Id);
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
        
        public IEnumerable<CategoryEntity> GetAll()
        {
            return _context.Category
                .Include(c => c.Commodities)
                .ToList();
        }
    }
}