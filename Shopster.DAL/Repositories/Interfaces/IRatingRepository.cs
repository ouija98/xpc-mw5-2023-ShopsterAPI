using Shopster.DAL.Entities;

namespace Shopster.DAL.Repositories.Interfaces;

public interface IRatingRepository : IRepository<RatingEntity>
{
    IEnumerable<RatingEntity> GetRatingsByCommodityId(Guid commodityId);
}