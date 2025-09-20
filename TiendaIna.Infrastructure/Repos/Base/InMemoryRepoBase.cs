using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public abstract class InMemoryRepoBase<TEntity, TKey> : IRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {

        private readonly IList<TEntity> _entities;

        protected InMemoryRepoBase(IList<TEntity> entities) {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        Task<IEnumerable<TEntity>> IRepo<TEntity, TKey>.GetAllAsync() => Task.FromResult(_entities.AsEnumerable());

        public Task<TEntity> GetAsync(TKey id) => Task.FromResult(_entities.Single(e => e.Id.Equals(id)));

        public Task<TKey> CreateAsync(TEntity entity) {
            if (_entities.Any(e => e.Id.Equals(entity.Id)))
                throw new InvalidOperationException($"Entity with id '{entity.Id}' already exists.");

            _entities.Add(entity);
            return Task.FromResult(entity.Id);
        }

        public Task<int> UpdateAsync(TEntity entity) {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var existingProduct = _entities.SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (existingProduct is null)
                throw new KeyNotFoundException();
            var existingIndex = _entities.IndexOf(existingProduct);
            _entities.RemoveAt(existingIndex);
            _entities.Insert(existingIndex, entity);
            return Task.FromResult(1);
        }

        public Task<int> DeleteAsync(TKey id) {
            var product = _entities.FirstOrDefault(p => p.Id.Equals(id));
            if (product == null)
                throw new KeyNotFoundException();

            _entities.Remove(product);
            return Task.FromResult(1);
        }
    }
}
