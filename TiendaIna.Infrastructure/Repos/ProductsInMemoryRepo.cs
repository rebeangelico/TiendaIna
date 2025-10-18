using TiendaIna.Core;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsInMemoryRepo : InMemoryRepoBase<Product, int>, IProductsRepo {
    private readonly IInMemoryProductsCategoriesStore _productCategoriesStore;

    public ProductsInMemoryRepo(IInMemoryProductsStore productsStore, IInMemoryProductsCategoriesStore productCategoriesStore) : base(productsStore) { 
        _productCategoriesStore = productCategoriesStore ?? throw new ArgumentNullException(nameof(productCategoriesStore));
    }

    public override Task<int> CreateAsync(Product entity) {
        entity.Id = Random.Shared.Next(1, 100000);
        return base.CreateAsync(entity);
    }

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) {
        ((List<ProductCategory>)_productCategoriesStore).RemoveBy(pc => pc.ProductId == productId);
        foreach(var catId in categoryIds)
            _productCategoriesStore.Add(new ProductCategory(productId, catId));
        return Task.CompletedTask;
    }
}
