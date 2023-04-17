namespace WebApplication1.Entities;

public class CategoryEntity : EntityBase
{
    public string Name { get; set; }
    public ICollection<CommodityEntity> Commodities { get; } = new List<CommodityEntity>();
}