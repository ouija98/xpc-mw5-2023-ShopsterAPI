using Shopster.Entities;

namespace Shopster.Shopster.DAL.Repositories
{
public class CommodityRepository : IRepository<CommodityEntity>
{
    private readonly AppDbContext.AppDbContext _context;

    public CommodityRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public Guid Create(CommodityEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        entity.Id = Guid.NewGuid();

        foreach (var rating in entity.Ratings)
        {
            rating.Id = Guid.NewGuid();
            _context.Rating.Add(rating);
        }

        _context.Commodity.Add(entity);
        _context.SaveChanges();

        return entity.Id;
    }

    public IEnumerable<CommodityEntity> GetAll()
    {
        return _context.Commodity.ToList();
    }

    public CommodityEntity GetById(Guid id)
    {
        return _context.Commodity.Single(s => s.Id == id);
    }

    public CommodityEntity Update(CommodityEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var existingCommodity = _context.Commodity.Single(s => s.Id == entity.Id);

        existingCommodity.Name = entity.Name;
        existingCommodity.Description = entity.Description;
        existingCommodity.Price = entity.Price;
        existingCommodity.Weight = entity.Weight;
        existingCommodity.Quantity = entity.Quantity;
        existingCommodity.Category = entity.Category;
        existingCommodity.Manufacturer = entity.Manufacturer;

        // remove old ratings that are not present in the updated commodity
        foreach (var oldRating in existingCommodity.Ratings.ToList())
        {
            if (!entity.Ratings.Contains(oldRating))
            {
                existingCommodity.Ratings.Remove(oldRating);
                _context.Rating.Remove(oldRating);
            }
        }

        // add new ratings that are not present in the existing commodity
        foreach (var newRating in entity.Ratings)
        {
            if (!existingCommodity.Ratings.Contains(newRating))
            {
                newRating.Id = Guid.NewGuid();
                existingCommodity.Ratings.Add(newRating);
                _context.Rating.Add(newRating);
            }
        }

        _context.SaveChanges();
        
        return existingCommodity;
    }

    public void Delete(Guid id)
    {
        var commodity = _context.Commodity.Single(s => s.Id == id);
        foreach (var rating in commodity.Ratings)
        {
            _context.Rating.Remove(rating);
        }

        _context.Commodity.Remove(commodity);
        _context.SaveChanges();
    }
}
}