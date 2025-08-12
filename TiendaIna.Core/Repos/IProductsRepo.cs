using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductsRepo {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProduct(int productId);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
