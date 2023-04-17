namespace Shopster.Entities;

public class RatingEntity : EntityBase
{
    public int Stars { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CommodityEntityId { get; set; }
    public CommodityEntity Commodity { get; set; } = null!;
}