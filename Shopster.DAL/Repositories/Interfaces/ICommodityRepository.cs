using Shopster.DAL.Entities;

namespace Shopster.DAL.Repositories.Interfaces;

public interface ICommodityRepository : IRepository<CommodityEntity>
{
    public IEnumerable<CommodityEntity> Search(string? name, decimal? minPrice, decimal? maxPrice, Guid? categoryId,
        int? minRating);
}