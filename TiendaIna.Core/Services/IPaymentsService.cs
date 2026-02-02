using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IPaymentsService {
        Task<List<PaymentModel>> GetAll();
        Task<OrderModel> Get(int id);
        Task<int> Add(PaymentModel entity);
        Task Update(PaymentModel entity);
        Task UpdateStatus(PaymentModel entity, PaymentStatus status);
        Task Delete(int Id);
    }
}
