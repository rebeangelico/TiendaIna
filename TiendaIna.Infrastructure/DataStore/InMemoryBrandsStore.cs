using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryBrandsStore : IList<Brand> { }

    public class InMemoryBrandsStore : List<Brand>, IInMemoryBrandsStore {
        public InMemoryBrandsStore() {
            Clear();
            AddRange([
              new Brand {
                Id = 1,
               Name = "Lattafa",
              },
              new Brand {
                Id = 2,
               Name = "Maison Alhambra",
              },
              new Brand {
                Id = 3,
               Name = "Armaf",
              },
              new Brand {
                Id = 4,
               Name = "French Avenue",
              },
              new Brand {
                Id = 5,
               Name = "Natura",
              },
              new Brand {
                Id = 6,
               Name = "Asdaf",
              },
              new Brand {
                Id = 7,
               Name = "Karssell",
              }
        ]);
        }
    }
}