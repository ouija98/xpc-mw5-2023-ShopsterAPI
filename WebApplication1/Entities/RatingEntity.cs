namespace WebApplication1.Entities;

/// <summary>
/// Represents a rating for a commodity entity.
/// </summary>
public record RatingEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the number of stars given in the rating.
    /// </summary>
    public int Stars { get; set; }

    /// <summary>
    /// Gets or sets the title of the rating.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the rating.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the ID of the commodity entity being rated.
    /// </summary>
    public Guid CommodityEntityId { get; set; }
}