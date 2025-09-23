using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> Get(int productId);
        Task Add(ProductModel product);
        Task Update(ProductModel product);
        Task Delete(int productId);
        public Task<IEnumerable<int>> GetCategoriesIds(int productId);
    }
}
