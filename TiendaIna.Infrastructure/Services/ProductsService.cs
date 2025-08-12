using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
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


        public async Task DeleteProduct(int productId) {
            await _productsRepo.DeleteProduct(productId);
        }



        public async Task UpdateProduct(ProductModel productModel) {
            var product = new Product(productModel);
            await _productsRepo.UpdateProduct(product);
        }
        public async Task AddProduct(ProductModel productModel) {
            var product = new Product(productModel);
            await _productsRepo.AddProduct(product);
        }

    }
}