using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface ICategoriesService {
        Task<List<CategoryModel>> GetAll();
        Task<CategoryModel> Get(int categoryId);
        Task<int> Add(CategoryModel category);
        Task Update(CategoryModel category);
        Task Delete(int categoryId);
        Task<IEnumerable<CategoryModel>> GetByProductAsync(int productId);
    }
}
