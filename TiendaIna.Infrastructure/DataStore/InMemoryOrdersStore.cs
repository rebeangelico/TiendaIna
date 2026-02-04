using TiendaIna.Core;
using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryOrdersStore : IList<Order> { }

    public class InMemoryOrdersStore : List<Order>, IInMemoryOrdersStore
    {
        public InMemoryOrdersStore() {
            Clear();
            AddRange([
              new Order {
                Id = 1,
                DateTime = new DateTime(22/01/2026),
                ClientId = 1,
                Amount = 84000,
                Status = OrderStatus.Pending,
              },
              new Order {
                Id = 2,
                DateTime = new DateTime(23/01/2026),
                ClientId = 2,
                Amount = 45000,
                Status = OrderStatus.Approved,
              },
              new Order {
                Id = 3,
                DateTime = new DateTime(24/01/2026),
                ClientId = 3,
                Amount = 86000,
                Status = OrderStatus.Approved,
              },
              new Order {
                Id = 4,
                DateTime = new DateTime(25/01/2026),
                ClientId = 4,
                Amount = 44000,
                Status = OrderStatus.Canceled,
              }
            ]);
        }
    }
}