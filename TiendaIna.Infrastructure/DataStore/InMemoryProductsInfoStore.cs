using TiendaIna.Core;
using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryProductsInfoStore : IList<ProductInfo> { }

    public class InMemoryProductsInfoStore : List<ProductInfo>, IInMemoryProductsInfoStore
    {
        public InMemoryProductsInfoStore() {
            Clear();
            AddRange([
              new ProductInfo {
                Id = 1,
                IdProduct = 1,
                IdOrder = 1,
                Name = "Oud for Glory",
                Quantity = 2,
                Price = 42000
              },
              new ProductInfo {
                Id = 2,
                IdProduct = 2,
                IdOrder = 2,
                Name = "Asad",
                Quantity = 1,
                Price = 45000
              },
              new ProductInfo {
                Id = 3,
                IdProduct = 3,
                IdOrder = 3,
                Name = "Ajwad",
                Quantity = 2,
                Price = 43000
              },
              new ProductInfo {
                Id = 4,
                IdProduct = 1,
                IdOrder = 4,
                Name = "Oud for Glory",
                Quantity = 1,
                Price = 44000
              },

            ]);
        }
    }
}