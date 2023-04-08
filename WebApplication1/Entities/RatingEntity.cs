

namespace projekt.Entities;

public record RatingEntity : EntityBase
{
    public int Stars { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }




}
