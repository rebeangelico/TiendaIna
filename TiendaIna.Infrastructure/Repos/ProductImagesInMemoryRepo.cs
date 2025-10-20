using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesInMemoryRepo : InMemoryRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesInMemoryRepo(IInMemoryProductImagesStore brandsStore) : base(brandsStore) { }

    public Task<IEnumerable<ProductImage>> GetByProductAsync(int productId) => Task.FromResult(_entities.Where(pi => pi.ProductId == productId));
}