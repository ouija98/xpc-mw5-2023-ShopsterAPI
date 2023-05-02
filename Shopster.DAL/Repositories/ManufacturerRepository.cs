﻿using Microsoft.EntityFrameworkCore;
using Shopster.DAL.Entities;

namespace Shopster.DAL.Repositories
{
    public class ManufacturerRepository : IRepository<ManufacturerEntity>
    {
        private readonly AppDbContext _context;

        public ManufacturerRepository(AppDbContext context)
        {
            _context = context;
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
        
        public IEnumerable<ManufacturerEntity> GetAll()
        {
            return _context.Manufacturer
                .Include(m => m.Commodities)
                .ToList();
        }
        
        public ManufacturerEntity GetById(Guid id)
        {
            var manufacturer = _context.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == id);

            if (manufacturer == null)
            {
                throw new ArgumentException($"No entity with id {id} exists in the database.", nameof(id));
            }

            return manufacturer;
        }

        public ManufacturerEntity Update(ManufacturerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingManufacturer = _context.Manufacturer
                .Include(m => m.Commodities)
                .Single(m => m.Id == entity.Id);

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