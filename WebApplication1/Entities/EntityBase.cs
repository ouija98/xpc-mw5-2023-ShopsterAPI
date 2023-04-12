namespace WebApplication1.Entities;

/// <summary>
/// Base class for entities that implements IEntity interface
/// </summary>
public abstract record class EntityBase : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }
}