using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class ProductsEFRepo : IProductsRepo {


        public void AddProduct(Product product) {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId) {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int productId) {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync() {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product) {
            throw new NotImplementedException();
        }
    }
}