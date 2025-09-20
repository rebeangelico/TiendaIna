using Microsoft.Data.SqlClient;
using RepoDb;

namespace TiendaIna.Infrastructure.Repos {                                 //IEntity<TKey> where TKey : notnull
    public abstract class DbRepoBase<TEntity, TKey> : BaseRepository<TEntity, SqlConnection> where TEntity : class {
        protected DbRepoBase(string connectionString) : base(connectionString) { }

        public IEnumerable<TEntity> GetAllAsync() {
            return QueryAll();
        }

        public TEntity GetById(TKey id) {
            return Query(id).FirstOrDefault()!;
        }

        public object Create(TEntity entity) {
            return Insert(entity);
        }

        public TKey CreateReturnID(TEntity entity) {
            return (TKey)Insert(entity);
        }

        public void UpdateEntity(TEntity entity) {
            Update(entity);
        }

        public void DeleteEntity(TKey id) {
            Delete(id);
        }
    }

}

