using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Repos;

namespace TiendaIna.Infrastructure.Services {
    public class ProductsService : IProductsService {

        private readonly InMemoryProductsRepo _productsRepo;
            public ProductsService(InMemoryProductsRepo productsRepo) { 
                this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
            }

        Task<List<Product>> IProductsService.GetProducts() {
            var products = _productsRepo.GetProductsEL();
            return Task.FromResult(products);
        }

        public Task<Product> GetProduct(int productId) {
            var products = _productsRepo.GetProductEL(1);
            return Task.FromResult(products);
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