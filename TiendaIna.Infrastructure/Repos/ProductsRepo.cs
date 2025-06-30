using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    internal class ProductsRepo : IProductsRepo {
        public Task<List<Product>> GetProductsAsync() {
            throw new NotImplementedException();
        }
    }
}
