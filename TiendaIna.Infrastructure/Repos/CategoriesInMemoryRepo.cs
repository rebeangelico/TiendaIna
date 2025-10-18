using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class CategoriesInMemoryRepo : InMemoryRepoBase<Category, int>, ICategoriesRepo {
    private readonly IInMemoryProductsCategoriesStore _productCategoriesStore;

    public CategoriesInMemoryRepo(IInMemoryCategoriesStore categoriesStore, IInMemoryProductsCategoriesStore productCategoriesStore) : base(categoriesStore) { 
        _productCategoriesStore = productCategoriesStore ?? throw new ArgumentNullException(nameof(productCategoriesStore));
    }

    public override Task<int> CreateAsync(Category entity) {
        entity.Id = Random.Shared.Next(1, 100000);
        return base.CreateAsync(entity);
    }

    public Task<IEnumerable<Category>> GetByProductAsync(int productId) {
        var categoryIds = _productCategoriesStore.Where(pc => pc.ProductId == productId).Select(pc => pc.CategoryId);
        return Task.FromResult(_entities.Where(c => categoryIds.Contains(c.Id)));
    }
}