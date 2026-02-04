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

    public Task<int> Add(ClientModel entity) {
        var Entity = Client.FromModel(entity);
       return _clientsRepo.CreateAsync(Entity);
    }

    public Task Delete(int Id){
        return _clientsRepo.DeleteAsync(Id);
    }

    public async Task<ClientModel> Get(int id) {
        var client = await _clientsRepo.GetAsync(id);
        var model = ClientModel.FromEntity(client);
        return model;
    }

    public async Task<List<ClientModel>> GetAll() {
        var clients = await _clientsRepo.GetAsync();
        var models = clients.Select(c => ClientModel.FromEntity(c)).ToList();
        return models;
    }

    public Task Update(ClientModel client) {
        var entity = Client.FromModel(client);
        return _clientsRepo.UpdateAsync(entity);
    }
}

