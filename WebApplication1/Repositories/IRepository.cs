using projekt.Entities;

namespace projekt.Repositories;

internal interface IRepository<TEntity> where TEntity: class, IEntity
{
    Guid Create(TEntity? entity);

    TEntity GetById(Guid id);

    TEntity Update(TEntity? entity);

    void Delete(Guid id);
    /// <summary>
    /// Gets all category entities.
    /// </summary>
    /// <returns>An enumerable of all category entities.</returns>
    IEnumerable<TEntity> GetAll();
}
