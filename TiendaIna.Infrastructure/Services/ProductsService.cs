using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Repos;

namespace TiendaIna.Infrastructure.Services {
    public class ProductsService : IProductsService {

        private readonly IProductsRepo _productsRepo;
            public ProductsService(IProductsRepo productsRepo) { 
                this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
            }

        Task<List<Product>> IProductsService.GetProducts() {
            return _productsRepo.GetProductsAsync();
        }

        public Task<Product> GetProduct(int productId) {
            return _productsRepo.GetProduct(1);
        }

        public void AddProduct(Product product) {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId) {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId) {
            throw new NotImplementedException();
        }
    }
}