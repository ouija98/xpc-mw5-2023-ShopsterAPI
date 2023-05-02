namespace Shopster.DTOs;

public class CommodityDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public float Weight { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
}