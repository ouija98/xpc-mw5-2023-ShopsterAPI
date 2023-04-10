﻿

namespace projekt.Entities;

public record CategoryEntity : EntityBase
{
    public string? Name { get; set; }
    public ICollection<CommodityEntity> Commodities { get; set; } = new List<CommodityEntity>();
}
