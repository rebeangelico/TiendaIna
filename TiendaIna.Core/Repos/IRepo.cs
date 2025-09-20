using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface IRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(TKey id);
    Task<TKey> CreateAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TKey id);
}