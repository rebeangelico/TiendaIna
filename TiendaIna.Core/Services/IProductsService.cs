using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(int productId);
        void DeleteProduct(int productId);

    }
}
