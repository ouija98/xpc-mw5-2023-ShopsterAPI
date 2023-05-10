using Shopster.DAL.Entities;

namespace Shopster.DAL.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Guid Create(TEntity entity);
    TEntity? GetById(Guid id);
    TEntity Update(TEntity entity);
    void Delete(Guid id);
    IEnumerable<TEntity> Get();
}