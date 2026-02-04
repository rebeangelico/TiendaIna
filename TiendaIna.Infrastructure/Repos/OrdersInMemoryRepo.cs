using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class OrdersInMemoryRepo : InMemoryRepoBase<Order, int>, IOrdersRepo
{
    public OrdersInMemoryRepo(IInMemoryOrdersStore ordersStore) : base(ordersStore) { }

    public override Task<int> CreateAsync(Order entity) {
        entity.Id = Random.Shared.Next(1, 100);
        return base.CreateAsync(entity);
    }
}