using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories.Interfaces;

namespace Shopster.DAL.Repositories
{
    public class ManufacturerRepository : IRepository<ManufacturerEntity>
    {
        private readonly AppDbContext _context;

        public ManufacturerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ManufacturerEntity> Get()
        {
            return _context.Manufacturer
                .Include(m => m.Commodities);
        }
        
        public Guid Create(ManufacturerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            _context.Manufacturer.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        
        
        public ManufacturerEntity? GetById(Guid id)
        {
            return _context.Manufacturer
                .Include(m => m.Commodities)
                .SingleOrDefault(m => m.Id == id);
        }

        public ManufacturerEntity Update(ManufacturerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingManufacturer = _context.Manufacturer
                .Include(m => m.Commodities)
                .SingleOrDefault(m => m.Id == entity.Id);
            if (existingManufacturer == null)
            {
                throw new ArgumentException($"Manufacturer with id {entity.Id} does not exist.");

            }
            existingManufacturer.Name = entity.Name;
            existingManufacturer.Description = entity.Description;
            existingManufacturer.Logo = entity.Logo;
            existingManufacturer.CountryOfOrigin = entity.CountryOfOrigin;
            existingManufacturer.Commodities = entity.Commodities;

            _context.SaveChanges();

            return existingManufacturer;
        }

        public void Delete(Guid id)
        {
            var manufacturer = _context.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == id);
            _context.Manufacturer.Remove(manufacturer);
            _context.SaveChanges();
        }
    }
}