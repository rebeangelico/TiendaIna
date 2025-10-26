using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryProductsCategoriesStore : IList<ProductCategory> { }

    public class InMemoryProductsCategoriesStore : List<ProductCategory>, IInMemoryProductsCategoriesStore {
        public InMemoryProductsCategoriesStore() {
            Clear();
            AddRange([
              new ProductCategory(1, 1),
              new ProductCategory(2, 2),
              new ProductCategory(2, 1),
              new ProductCategory(3, 3),
              new ProductCategory(3, 1),
              new ProductCategory(3, 2),
              new ProductCategory(4, 4),
              new ProductCategory(5, 5),
              new ProductCategory(6, 1),
              new ProductCategory(6, 2),
              new ProductCategory(7, 7),
              new ProductCategory(7, 8),
              new ProductCategory(8, 1),
              new ProductCategory(8, 2),
              new ProductCategory(9, 3),
              new ProductCategory(9, 4),
              new ProductCategory(10, 5),
              new ProductCategory(10, 6),
              new ProductCategory(11, 7),
              new ProductCategory(11, 8),
              new ProductCategory(12, 1),
              new ProductCategory(12, 2),
            ]);
        }
    }
}
