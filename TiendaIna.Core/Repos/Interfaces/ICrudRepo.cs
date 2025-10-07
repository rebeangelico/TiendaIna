using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface ICrudRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(TKey id);
    Task<TKey> CreateAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TKey id);
}