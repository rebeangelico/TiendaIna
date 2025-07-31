using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface InMemoryProductsRepo {
        List<Product> GetProductsEL();
        Product GetProductEL(int productId);

    }
}
