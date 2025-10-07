using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryProductImagesStore : IList<ProductImage> { }

    public class InMemoryProductImagesStore : List<ProductImage>, IInMemoryProductImagesStore {
        public InMemoryProductImagesStore() {
            Clear();
            AddRange([
              new ProductImage {
                Id = 1,
                ProductId = 1,
                ImageId = 1,
                IsCover = true,
              },
              new ProductImage {
                Id = 2,
                ProductId = 1,
                ImageId = 2,
                IsCover = false,
              },
              new ProductImage {
                Id = 3,
                ProductId = 2,
                ImageId = 3,
                IsCover = true,
              },
              new ProductImage {
                Id = 4,
                ProductId = 2,
                ImageId = 4,
                IsCover = false,
              },
              new ProductImage {
                Id = 5,
                ProductId = 2,
                ImageId = 5,
                IsCover = false,
              },
              new ProductImage {
                Id = 6,
                ProductId = 3,
                ImageId = 6,
                IsCover = true,
              },
              new ProductImage {
                Id = 7,
                ProductId = 4,
                ImageId = 7,
                IsCover = true,
              },
              new ProductImage {
                Id = 8,
                ProductId = 4,
                ImageId = 8,
                IsCover = false,
              }
        ]);
        }
    }
}