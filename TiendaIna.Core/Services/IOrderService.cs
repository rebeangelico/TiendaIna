using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IOrderService {
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> Get(int id);
        Task<int> Add(OrderModel entity);
        Task Update(OrderModel entity);
        Task UpdateStatus(OrderModel entity, OrderStatus status);
        Task Delete(int Id);
    }
}
