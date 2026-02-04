using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class PaymentsInMemoryRepo : InMemoryRepoBase<Payment, int>, IPaymentsRepo
{
    public PaymentsInMemoryRepo(IInMemoryPaymentsStore PaymentsStore) : base(PaymentsStore) { }

    public override Task<int> CreateAsync(Payment entity) {
        entity.Id = Random.Shared.Next(1, 100);
        return base.CreateAsync(entity);
    }

    public Task<IEnumerable<Payment>> GetByOrder(int orderId)
    {
         var element = Task.FromResult(_entities.Where(e => e.OrderId.Equals(orderId)));
        return element;
    }
}