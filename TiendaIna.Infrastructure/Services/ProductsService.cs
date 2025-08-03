using Microsoft.AspNetCore.Http.HttpResults;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Repos;

namespace TiendaIna.Infrastructure.Services {
    public class ProductsService : IProductsService {

        private readonly IProductsRepo _productsRepo;
            public ProductsService(IProductsRepo productsRepo) { 
                this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
            }

        public async Task<List<ProductModel>> GetProducts() {
            var products = await _productsRepo.GetProductsAsync();
            var models = products.Select(p => new ProductModel(p)).ToList();
            return models;
        }

        public Task<ProductModel> GetProduct(int productId) {
            var product = _productsRepo.GetProduct(productId).Result;
            var model = new ProductModel(product);
            return Task.FromResult(model);
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