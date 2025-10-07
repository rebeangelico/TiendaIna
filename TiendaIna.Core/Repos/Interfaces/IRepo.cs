using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface IRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
}