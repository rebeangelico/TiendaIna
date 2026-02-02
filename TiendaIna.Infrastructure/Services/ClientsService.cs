using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class ClientsService : IClientsService {
    private readonly IClientsRepo _clientsRepo;

    public ClientsService(IClientsRepo clientsRepo) {
        this._clientsRepo = clientsRepo ?? throw new ArgumentNullException(nameof(clientsRepo));
    }

    public Task<int> Add(ClientModel entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ClientModel> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ClientModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(ClientModel entity)
    {
        throw new NotImplementedException();
    }
}

