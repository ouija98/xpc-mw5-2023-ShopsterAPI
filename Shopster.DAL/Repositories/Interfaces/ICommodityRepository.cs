using Shopster.DAL.Entities;

namespace Shopster.DAL.Repositories.Interfaces;

public interface ICommodityRepository : IRepository<CommodityEntity>
{
    public IEnumerable<CommodityEntity> Search(
        string? name,
        decimal? minPrice,
        decimal? maxPrice,
        Guid? categoryId,
        int? minRating,
        string? manufacturerIdOrName);
    
    IEnumerable<CommodityEntity> GetTopRatedCommodities();

    public IEnumerable<CommodityEntity> Sort(IEnumerable<CommodityEntity> commodities, string sort);
}