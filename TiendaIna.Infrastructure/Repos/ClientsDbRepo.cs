using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ClientsDbRepo : CrudDbRepoBase<Client, int>, IClientsRepo {
    public ClientsDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

}

