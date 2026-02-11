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
                DateTime = new DateTimeOffset(2026, 02, 08, 12, 22, 5, TimeSpan.Zero),
                ClientId = 1,
                Amount = 194000,
                Status = OrderStatus.Pending,
              },
              new Order {
                Id = 2,
                DateTime =  new DateTimeOffset(2026, 02, 09, 22, 10, 55, TimeSpan.Zero),
                ClientId = 2,
                Amount = 45000,
                Status = OrderStatus.Approved,
              },
              new Order {
                Id = 3,
                DateTime =  new DateTimeOffset(2026, 02, 10, 21, 42, 25, TimeSpan.Zero),
                ClientId = 3,
                Amount = 86000,
                Status = OrderStatus.Approved,
              },
              new Order {
                Id = 4,
                DateTime =  new DateTimeOffset(2026, 02, 11, 20, 12, 45, TimeSpan.Zero),
                ClientId = 4,
                Amount = 44000,
                Status = OrderStatus.Canceled,
              }
            ]);
        }
    }
}