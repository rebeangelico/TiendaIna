using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryCategoriesStore : IList<Category> { }

    public class InMemoryCategoriesStore : List<Category>, IInMemoryCategoriesStore {
        public InMemoryCategoriesStore() {
            Clear();
            AddRange([
              new Category {
                Id = 1,
               Name = "Perfumes Arabes",
              },
              new Category {
                Id = 2,
               Name = "Masculinos",
              },
              new Category {
                Id = 3,
               Name = "Femeninos",
              },
              new Category {
                Id = 4,
               Name = "Unisex",
              },
              new Category {
                Id = 5,
               Name = "Infantiles",
              },
              new Category {
                Id = 6,
               Name = "Perfumes Franceses",
              },
              new Category {
                Id = 7,
               Name = "Productos Capilares",
              },
              new Category {
                Id = 8,
               Name = "Ofertas",
              },
        ]);
        }
    }
}