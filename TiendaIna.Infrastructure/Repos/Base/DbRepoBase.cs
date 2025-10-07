using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public abstract class DbRepoBase<TEntity, TKey> : BaseRepository<TEntity, SqlConnection>, IRepo<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : notnull {
    protected DbRepoBase(IOptions<AppSettings> appSettings) : base(appSettings?.Value?.ConnectionStrings?.SqlServer, RepoDb.Enumerations.ConnectionPersistency.Instance) { }
}

