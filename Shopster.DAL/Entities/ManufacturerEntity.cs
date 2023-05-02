namespace Shopster.DAL.Entities;

public class ManufacturerEntity : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public string CountryOfOrigin { get; set; }
    public ICollection<CommodityEntity>? Commodities { get; set; } = new List<CommodityEntity>();
}