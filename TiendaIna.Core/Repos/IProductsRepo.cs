using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductsRepo {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
