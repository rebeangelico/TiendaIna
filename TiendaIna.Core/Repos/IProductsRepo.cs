using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductsRepo {
        Task<List<Product>> GetAsync();
        Task<Product> Get(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
