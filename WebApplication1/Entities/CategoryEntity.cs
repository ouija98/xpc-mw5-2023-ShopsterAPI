

namespace projekt.Entities;

public record CategoryEntity : EntityBase
{
    public Guid CategoryId {get; set;}
    public string? Name { get; set; }
    public List<CommodityEntity> Commodities { get; set; }
}
