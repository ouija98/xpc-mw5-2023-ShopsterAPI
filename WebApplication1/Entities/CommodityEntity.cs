

namespace projekt.Entities;

public record CommodityEntity : EntityBase
{
    public string? Name { get; set; }

    public string? Picture { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public float Weight { get; set; }

    public int Quantity { get; set; }

    public Guid? CategoryId { get; set; }  // foreign key property

    public Guid? ManufacturerId { get; set; }  // foreign key property
    
    public List<RatingEntity>? Ratings { get; set; }
    
}
