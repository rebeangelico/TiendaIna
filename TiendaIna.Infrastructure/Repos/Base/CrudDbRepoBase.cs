using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Linq.Expressions;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public abstract class CrudDbRepoBase<TEntity, TKey> : DbRepository<SqlConnection>, ICrudRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
    protected CrudDbRepoBase(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.ConnectionStrings?.SqlServer, RepoDb.Enumerations.ConnectionPersistency.Instance) { }

    #region ICrudRepo interface methods
    public Task<IEnumerable<TEntity>> GetAsync() => QueryAllAsync<TEntity>();
    public async Task<TEntity> GetAsync(TKey id) => (await QueryAsync<TEntity>(id)).FirstOrDefault()!;
    public Task<IEnumerable<TEntity>> GetAsync(TKey[] ids) => QueryAsync(e => ids.Contains(e.Id));
    public async Task<TKey> CreateAsync(TEntity entity) => (TKey)(await InsertAsync(entity));
    public Task<int> UpdateAsync(TEntity entity) => base.UpdateAsync(entity);
    public Task<int> DeleteAsync(TKey id) => base.DeleteAsync<TEntity>(id);
    #endregion

    #region helper methods for internal use
    protected Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> where, IEnumerable<Field>? fields = null, IEnumerable<OrderField>? orderBy = null, int? top = 0) => QueryAsync<TEntity>(where, fields, orderBy, top);
    
    protected async Task<TCount> MaxAsync<TCount>(Field field, Expression<Func<TEntity, bool>>? where = null) => (TCount)(await base.MaxAsync<TEntity>(field, where));
    #endregion
}

