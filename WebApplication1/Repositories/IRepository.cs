using WebApplication1.Entities;

namespace WebApplication1.Repositories;

/// <summary>
/// An internal interface for repository classes that interact with entities that implement the IEntity interface.
/// </summary>
/// <typeparam name="TEntity">The type of entity the repository interacts with.</typeparam>
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Creates a new entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>The unique identifier of the newly created entity.</returns>
    Guid Create(TEntity? entity);

    /// <summary>
    /// Gets the entity with the specified identifier from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier.</returns>
    TEntity GetById(Guid id);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    TEntity Update(TEntity? entity);

    /// <summary>
    /// Deletes the entity with the specified identifier from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    void Delete(Guid id);

    /// <summary>
    /// Gets all entities of the specified type from the repository.
    /// </summary>
    /// <returns>An enumerable of all entities of the specified type.</returns>
    IEnumerable<TEntity> GetAll();
}