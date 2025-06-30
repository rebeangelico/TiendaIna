using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductsRepo {
        Task<List<Product>> GetProductsAsync();

    }
}
