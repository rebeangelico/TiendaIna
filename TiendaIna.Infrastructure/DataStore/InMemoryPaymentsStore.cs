using TiendaIna.Core;
using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryPaymentsStore : IList<Payment> { }

    public class InMemoryPaymentsStore : List<Payment>, IInMemoryPaymentsStore
    {
        public InMemoryPaymentsStore() {
            Clear();
            AddRange([
              new Payment {
                Id = 1,
                OrderId = 2,
                Estado = PaymentStatus.Approved,
                Details = "Pago con visa",
                Amount = 100000,
                ClientId = 1,
              },
              new Payment {
                Id = 2,
                OrderId = 3,
                Estado = PaymentStatus.Pending,
                Details = "Transferencia bancaria",
                Amount = 250000,
                ClientId = 2,
              },
              new Payment {
                Id = 3,
                OrderId = 1,
                Estado = PaymentStatus.Rejected,
                Details = "Pago con mastercard",
                Amount = 75000,
                ClientId = 3,
              },
              new Payment {
                Id = 4,
                OrderId = 4,
                Estado = PaymentStatus.Approved,
                Details = "Pago en efectivo",
                Amount = 50000,
                ClientId = 4,
              },
              new Payment {
                Id = 5,
                OrderId = 5,
                Estado = PaymentStatus.Pending,
                Details = "Pago con paypal",
                Amount = 95000,
                ClientId = 5,
              },
              new Payment {
                Id = 6,
                OrderId = 5,
                Estado = PaymentStatus.Approved,
                Details = "Pago con débito",
                Amount = 95000,
                ClientId = 5,
              }
            ]);
        }
    }
}