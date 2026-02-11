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
                Status = PaymentStatus.Approved,
                DateTime = DateTime.Now,
                Method = "Visa",
                Details = "Pago con visa",
                Amount = 45000,
                ClientId = 1,
              },
              new Payment {
                Id = 2,
                OrderId = 3,
                Status = PaymentStatus.Pending,
                DateTime = DateTime.Now,
                Details = "Transferencia bancaria",
                Amount = 86000,
                ClientId = 3,
              },
              new Payment {
                Id = 3,
                OrderId = 1,
                Status = PaymentStatus.Rejected,
                Method = "Mastercard",
                DateTime = DateTime.Now,
                Details = "Pago con mastercard",
                Amount = 194000,
                ClientId = 3,
              },
              new Payment {
                Id = 7,
                OrderId = 1,
                Status = PaymentStatus.Approved,
                Method = "Mercado Pago",
                DateTime = DateTime.Now,
                Details = "Mercado Pago",
                Amount = 194000,
                ClientId = 3,
              },
              new Payment {
                Id = 4,
                OrderId = 4,
                Status = PaymentStatus.Rejected,
                Method = "Mercado Pago",
                DateTime = DateTime.Now,
                Details = "",
                Amount = 43000,
                ClientId = 4,
              },
              new Payment {
                Id = 5,
                OrderId = 5,
                Status = PaymentStatus.Pending,
                Details = "Pago con paypal",
                DateTime = DateTime.Now,
                Amount = 95000,
                ClientId = 5,
              },
              new Payment {
                Id = 6,
                OrderId = 5,
                Status = PaymentStatus.Approved,
                Details = "Pago con débito",
                DateTime = DateTime.Now,
                Amount = 95000,
                ClientId = 5,
              }
            ]);
        }



    }
}