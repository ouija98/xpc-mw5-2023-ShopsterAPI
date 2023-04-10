using projekt;
using projekt.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using projekt.Repositories;

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
            existingManufacturer.Commodities = entity.Commodities;

            Database.Instance.SaveChanges();

            return existingManufacturer;
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            var manufacturer = Database.Instance.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == id);

            foreach (var commodity in manufacturer.Commodities)
            {
                commodity.Manufacturer = null;
            }

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

        /// <summary>
        /// Adds a commodity to a manufacturer's list of commodities.
        /// </summary>
        /// <param name="manufacturerId">The id of the manufacturer.</param>
        /// <param name="commodity">The commodity to add.</param>
        public void AddCommodity(Guid manufacturerId, CommodityEntity commodity)
        {
            var manufacturer = GetById(manufacturerId);
            manufacturer.Commodities.Add(commodity);
            commodity.Manufacturer = manufacturer;

            Database.Instance.SaveChanges();
        }

        /// <summary>
        /// Removes a commodity from a manufacturer's list of commodities.
        /// </summary>
        /// <param name="manufacturerId">The id of the manufacturer.</param>
        /// <param name="commodity">The commodity to remove.</param>
        /// <returns>Returns true if the commodity was removed; false otherwise.</returns>
        public bool RemoveCommodity(Guid manufacturerId, CommodityEntity commodity)
        {
            var manufacturer = GetById(manufacturerId);
            commodity.Manufacturer = null;

            bool result = manufacturer.Commodities.Remove(commodity);
            Database.Instance.SaveChanges();

            return result;
        }
    }
}