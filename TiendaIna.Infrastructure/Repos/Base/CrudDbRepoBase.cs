using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public abstract class CrudDbRepoBase<TEntity, TKey> : DbRepository<SqlConnection>, ICrudRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
    protected CrudDbRepoBase(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.ConnectionStrings?.SqlServer, RepoDb.Enumerations.ConnectionPersistency.Instance) { }

    public Task<IEnumerable<TEntity>> GetAsync() => QueryAllAsync<TEntity>();
    public async Task<TEntity> GetAsync(TKey id) => (await QueryAsync<TEntity>(id)).FirstOrDefault()!;
    public async Task<TKey> CreateAsync(TEntity entity) => (TKey)(await InsertAsync(entity));
    public Task<int> UpdateAsync(TEntity entity) => base.UpdateAsync(entity);
    public Task<int> DeleteAsync(TKey id) => base.DeleteAsync<TEntity>(id);
}

