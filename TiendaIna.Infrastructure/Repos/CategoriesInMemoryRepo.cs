using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class CategoriesInMemoryRepo : InMemoryRepoBase<Category, int>, ICategoriesRepo {
    public CategoriesInMemoryRepo(IInMemoryCategoriesStore categoriesStore) : base(categoriesStore) { }

}