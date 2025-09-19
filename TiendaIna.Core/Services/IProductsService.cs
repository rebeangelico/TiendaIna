using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int productId);
        Task AddProduct(ProductModel product);
        Task UpdateProduct(ProductModel product);
        Task DeleteProduct(int productId);
        public Task<IEnumerable<int>> GetCategoriesIds(int productId);
    }
}
