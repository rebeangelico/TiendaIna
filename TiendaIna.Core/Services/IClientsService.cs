using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IClientsService {
        Task<List<ClientModel>> GetAll();
        Task<ClientModel> Get(int id);
        Task<int> Add(ClientModel entity);
        Task Update(ClientModel entity);
        Task Delete(int Id);
    }
}
