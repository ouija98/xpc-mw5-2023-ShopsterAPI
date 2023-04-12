namespace WebApplication1.Entities;

/// <summary>
/// Represents a manufacturer entity in the application.
/// </summary>
public record ManufacturerEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the name of the manufacturer.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the manufacturer.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the logo of the manufacturer.
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    /// Gets or sets the country of origin of the manufacturer.
    /// </summary>
    public string? CountryOfOrigin { get; set; }

    /// <summary>
    /// Gets or sets the commodities produced by the manufacturer.
    /// </summary>
    public List<CommodityEntity> Commodities { get; set; }
}