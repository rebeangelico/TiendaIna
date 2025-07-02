using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Services {
    public interface ICategoriesService {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
