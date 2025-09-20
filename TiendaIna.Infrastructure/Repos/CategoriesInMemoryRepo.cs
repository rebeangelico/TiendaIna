using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class CategoriesInMemoryRepo : InMemoryRepoBase<Category, int>, ICategoriesRepo {
    public CategoriesInMemoryRepo(IInMemoryCategoriesStore categoriesStore) : base(categoriesStore) { }

}