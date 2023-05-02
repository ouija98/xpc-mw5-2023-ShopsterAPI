namespace Shopster.DAL.Entities
{
    public class CommodityEntity : EntityBase
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; } = null!;
        public ICollection<RatingEntity>? Ratings { get;  } = new List<RatingEntity>();
    }
}