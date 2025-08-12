using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int productId);
        Task AddProduct(ProductModel product);
        Task UpdateProduct(ProductModel product);
        Task DeleteProduct(int productId);
    }
}
