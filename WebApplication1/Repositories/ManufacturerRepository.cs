using projekt;
using projekt.Entities;
using projekt.Repositories;

namespace WebApplication1.Repositories;

/// <summary>
/// The repository for managing <see cref="ManufacturerEntity"/> entities.
/// </summary>
public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    public Guid Create(ManufacturerEntity? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        entity.Id = Guid.NewGuid();
        Database.Instance.Manufacturers.Add(entity);

        return entity.Id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        return Database.Instance.Manufacturers.Single(m => m.Id == id);
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var existingManufacturer = Database.Instance.Manufacturers.Single(m => m.Id == entity.Id);
        existingManufacturer.Name = entity.Name;
        existingManufacturer.Description = entity.Description;
        existingManufacturer.Logo = entity.Logo;
        existingManufacturer.CountryOfOrigin = entity.CountryOfOrigin;

        return existingManufacturer;
    }

    public void Delete(Guid id)
    {
        var manufacturer = Database.Instance.Manufacturers.Single(m => m.Id == id);

        foreach (var commodity in manufacturer.Commodities)
        {
            commodity.Manufacturer = null;
        }

        Database.Instance.Manufacturers.Remove(manufacturer);
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
        return manufacturer.Commodities.Remove(commodity);
    }
}