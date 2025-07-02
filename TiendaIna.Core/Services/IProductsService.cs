using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(int productId);
        void DeleteProduct(int productId);

        public Product GetProductPruebas();
    }
}
