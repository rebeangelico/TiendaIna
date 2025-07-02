using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface ICategoriesRepo {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategory(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(int categoryId);
        void DeleteCategory(int categoryId);

    }
}
