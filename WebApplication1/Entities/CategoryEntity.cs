namespace WebApplication1.Entities;

public record CategoryEntity : EntityBase
{
    public string? Name { get; set; }
    public List<CommodityEntity> Commodities { get; set; }
}