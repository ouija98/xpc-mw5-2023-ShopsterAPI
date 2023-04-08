

using projekt.Entities;

namespace WebApplication1;

public class MyAppConfiguration
{
    public string? Name { get; set; }

    public string? Picture { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public float Weight { get; set; }

    public int Quantity { get; set; }

    public CategoryEntity? Category { get; set; }

    public ManufacturerEntity? Manufacturer { get; set; }

    public RatingEntity? Rating { get; set; }
}