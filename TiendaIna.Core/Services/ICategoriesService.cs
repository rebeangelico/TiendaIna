using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface ICategoriesService {
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int categoryId);
        Task AddCategory(CategoryModel category);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategory(int categoryId);
    }
}
