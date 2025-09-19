using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure {
    public interface IInMemoryCategoriesStore : IList<Category> { }

    public class InMemoryCategoriesStore : List<Category>, IInMemoryCategoriesStore {
        public InMemoryCategoriesStore() {
            this.Clear();
            this.AddRange([
              new Category {
                Id = 1,
               Name = "Perfumes Arabes",
              },
              new Category {
                Id = 2,
               Name = "Perfumes Masculinos",
              },
              new Category {
                Id = 3,
               Name = "Perfumes Femeninos",
              },
              new Category {
                Id = 4,
               Name = "Perfumes Unisex",
              },
              new Category {
                Id = 5,
               Name = "Perfumes Infantiles",
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