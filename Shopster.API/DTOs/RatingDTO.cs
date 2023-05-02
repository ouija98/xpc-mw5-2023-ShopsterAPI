namespace Shopster.DTOs;

public class RatingDTO
{
    public Guid Id { get; set; }
    public int Stars { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CommodityEntityId { get; set; }
}