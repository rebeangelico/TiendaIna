using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface ICategoriesService {
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int categoryId);
        void AddCategory(CategoryModel category);
        void UpdateCategory(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
