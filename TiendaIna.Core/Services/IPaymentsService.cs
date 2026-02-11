using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IPaymentsService {
        Task<List<PaymentModel>> GetAll();
        Task<PaymentModel> Get(int id);
        Task<List<PaymentModel>> GetFromOrder(int OrderId);
        Task<int> Add(PaymentModel entity);
        Task Update(PaymentModel entity);
        Task UpdateStatus(int id, PaymentStatus status);
        Task Delete(int Id);
    }
}
