using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.Repos {
    public abstract class InMemoryRepoBase<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : notnull {

        private readonly IList<TEntity> _entities;

        protected InMemoryRepoBase(IList<TEntity> entities) {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        public Task Add(TEntity entity) {
            if (_entities.Any(e => e.Id.Equals(entity.Id)))
                throw new InvalidOperationException($"Entity with id '{entity.Id}' already exists.");

            _entities.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id) {
            var product = _entities.FirstOrDefault(p => p.Id.Equals(id));
            if (product == null)
                throw new KeyNotFoundException();

            _entities.Remove(product);
            return Task.CompletedTask;
        }


        public async Task<TEntity> GetAsync(int id) => (await GetAllAsync()).Single(p => p.Id.Equals(id));

        public Task<List<TEntity>> GetAllAsync() => Task.FromResult((List<TEntity>)_entities);

        public Task Update(TEntity entity) {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var existingProduct = _entities.SingleOrDefault(p => p.Id .Equals(entity.Id));
            if (existingProduct is null)
                throw new KeyNotFoundException();
            var existingIndex = _entities.IndexOf(existingProduct);
            _entities.RemoveAt(existingIndex);
            _entities.Insert(existingIndex, entity);
            return Task.CompletedTask;
        }

    }
}
