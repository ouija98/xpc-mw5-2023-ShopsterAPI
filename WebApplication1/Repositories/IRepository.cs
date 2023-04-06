using projekt.Entities;

namespace projekt.Repositories;

internal interface IRepository<TEntity> where TEntity: class, IEntity
{
    Guid Create(TEntity? entity);

    TEntity GetById(Guid id);

    TEntity Update(TEntity? entity);

    void Delete(Guid id);

}
