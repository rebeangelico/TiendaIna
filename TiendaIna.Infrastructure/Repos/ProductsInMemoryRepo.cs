using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsInMemoryRepo : InMemoryRepoBase<Product, int>, IProductsRepo {
    public ProductsInMemoryRepo(IInMemoryProductsStore productsStore) : base(productsStore) { }
}
