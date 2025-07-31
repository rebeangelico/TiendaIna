using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface InMemoryCategoriesRepo {
        List<Category> GetCategoriesEL();
        Category GetCategoryEL(int categoryId);

    }
}
