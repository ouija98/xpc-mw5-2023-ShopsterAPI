namespace WebApplication1.Entities
{
    public class CommodityEntity : EntityBase
    {
        /// <summary>
        /// Gets or sets the name of the commodity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the picture of the commodity.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the description of the commodity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the commodity.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the weight of the commodity.
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the commodity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the category entity of the commodity.
        /// </summary>
        public CategoryEntity Category { get; set; }

        /// <summary>
        /// Gets or sets the category entity ID of the commodity.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer entity ID of the commodity.
        /// </summary>
        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer entity of the commodity.
        /// </summary>
        public ManufacturerEntity Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the star rating of the commodity.
        /// </summary>
        public int Stars { set; get; }

        /// <summary>
        /// Gets or sets the list of rating entities for the commodity.
        /// </summary>
        public ICollection<RatingEntity>? Ratings { get; set; }
    }
}