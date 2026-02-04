using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsInfoInMemoryRepo : InMemoryRepoBase<ProductInfo, int>, IProductsInfoRepo
{
    public ProductsInfoInMemoryRepo(IInMemoryProductsInfoStore ProductsInfoStore) : base(ProductsInfoStore) { }

    public override Task<int> CreateAsync(ProductInfo entity) {
        entity.Id = Random.Shared.Next(1, 100);
        return base.CreateAsync(entity);
    }

    public Task<IEnumerable<ProductInfo>> GetByOrder(int orderId) => Task.FromResult(_entities.Where(pi => pi.OrderId == orderId));
}