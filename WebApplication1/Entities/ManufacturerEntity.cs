

namespace projekt.Entities;

public record ManufacturerEntity : EntityBase
{
    public Guid ManufacturerId {get; set;}
    
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Logo { get; set; }

    public string? CountryOfOrigin { get; set; }

    public List<CommodityEntity> Commodities { get; set; }
    
}
