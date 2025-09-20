using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public abstract class DbRepoBase<TEntity, TKey> : BaseRepository<TEntity, SqlConnection>, IRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
        protected DbRepoBase(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.ConnectionStrings?.SqlServer, RepoDb.Enumerations.ConnectionPersistency.Instance) { }

        public Task<IEnumerable<TEntity>> GetAllAsync() => QueryAllAsync();
        public async Task<TEntity> GetAsync(TKey id) => (await QueryAsync(id)).FirstOrDefault()!;
        public async Task<TKey> CreateAsync(TEntity entity) => (TKey)(await InsertAsync(entity));
        public Task<int> UpdateAsync(TEntity entity) => base.UpdateAsync(entity);
        public Task<int> DeleteAsync(TKey id) => base.DeleteAsync(id);
    }

}

