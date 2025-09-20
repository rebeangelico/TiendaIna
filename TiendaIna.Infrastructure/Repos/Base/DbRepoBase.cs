using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Infrastructure.Repos {
    public abstract class DbRepoBase<TEntity, TKey> : BaseRepository<TEntity, SqlConnection> where TEntity : class, IEntity<TKey> where TKey : notnull {
        protected DbRepoBase(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.ConnectionStrings?.SqlServer, RepoDb.Enumerations.ConnectionPersistency.Instance) { }

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

