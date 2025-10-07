using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface IProductsRepo : ICrudRepo<Product, int> {
    Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds);
}