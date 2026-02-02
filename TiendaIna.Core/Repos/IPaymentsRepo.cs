using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface IPaymentsRepo : ICrudRepo<Payment, int> { 
    Task<IEnumerable<Payment>> GetByOrder(int orderId);

}