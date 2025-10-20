using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<ProductModel>> Get();
        Task<ProductModel> Get(int productId);
        Task Add(ProductModel product);
        Task Update(ProductModel product);
        Task Delete(int productId);

        Task<IEnumerable<CategoryModel>> GetCategoriesAsync(int productId);
        Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds);

    }
}
