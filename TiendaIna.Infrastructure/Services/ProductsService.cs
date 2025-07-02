using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services {
    public class ProductsService : IProductsService {
        public Task<List<Product>> GetProducts() {
            throw new NotImplementedException();
        }
        public Product GetProductPruebas() {
            return new Product() {
                category = "arabe",
                name = "The Lions",
                description = "exquisito bla bla bla",
                imagen = "https://bestbrandsperfume.com/wp-content/uploads/2024/11/ARMAF-THE-LIONS-CLUB-RUGIR-3.4-Oz-Eau-De-Parfum-For-Men.png",
                precio = 50000
            };
        }

        public Task<Product> GetProduct(int productId) {
            throw new NotImplementedException();
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