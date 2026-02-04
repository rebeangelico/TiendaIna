using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IOrdersService {
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> Get(int id);
        Task<int> Add(OrderModel entity);
        Task Update(OrderModel entity);
        Task UpdateStatus(int id, OrderStatus status);
        Task Delete(int Id);
    }
}
