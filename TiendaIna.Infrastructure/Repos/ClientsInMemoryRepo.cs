using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ClientsInMemoryRepo : InMemoryRepoBase<Client, int>, IClientsRepo {
    public ClientsInMemoryRepo(IInMemoryClientsStore ClientsStore) : base(ClientsStore) { }

    public override Task<int> CreateAsync(Client entity) {
        entity.Id = Random.Shared.Next(1, 100);
        return base.CreateAsync(entity);
    }
}