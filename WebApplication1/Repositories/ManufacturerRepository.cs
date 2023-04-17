using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// The repository for managing <see cref="ManufacturerEntity"/> entities.
    /// </summary>
    public class ManufacturerRepository : IRepository<ManufacturerEntity>
    {
        /// <inheritdoc/>
        public Guid Create(ManufacturerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            Database.Instance.Manufacturer.Add(entity);
            Database.Instance.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc/>
        public ManufacturerEntity GetById(Guid id)
        {
            return Database.Instance.Manufacturer
                .Include(m => m.Commodities)
                .SingleOrDefault(m => m.Id == id);
        }

        /// <inheritdoc/>
        public ManufacturerEntity Update(ManufacturerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingManufacturer = Database.Instance.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == entity.Id);

            existingManufacturer.Name = entity.Name;
            existingManufacturer.Description = entity.Description;
            existingManufacturer.Logo = entity.Logo;
            existingManufacturer.CountryOfOrigin = entity.CountryOfOrigin;
            //existingManufacturer.Commodities = entity.Commodities;

            Database.Instance.SaveChanges();

            return existingManufacturer;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var manufacturer = Database.Instance.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == id);
            Database.Instance.Manufacturer.Remove(manufacturer);
            Database.Instance.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<ManufacturerEntity> GetAll()
        {
            return Database.Instance.Manufacturer
                .Include(m => m.Commodities)
                .ToList();
        }
    }
}