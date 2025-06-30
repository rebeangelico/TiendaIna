using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Services {
    public interface IProductsService {
        Task<List<Product>> GetProducts();
    }
}
