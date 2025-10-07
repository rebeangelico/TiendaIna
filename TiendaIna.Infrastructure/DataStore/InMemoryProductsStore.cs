using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryProductsStore : IList<Product> { }

    public class InMemoryProductsStore : List<Product>, IInMemoryProductsStore {
        private readonly IInMemoryCategoriesStore _categories;
        public InMemoryProductsStore(IInMemoryCategoriesStore categories) {
            _categories = categories;

            Clear();
            AddRange([
              new Product {
                Id = 1,
                BrandId = 1,
                Name = "Oud for Glory",
                DescriptionShort = "es una fragancia unisex profunda y misteriosa, con un equilibrio entre notas amaderadas, especiadas y dulces. Perfecta para quienes desean un aroma intenso, seductor y envolvente.",
                Description ="Es una fragancia unisex que pertenece a la familia olfativa ámbar amaderada, destacándose por su combinación de notas especiadas, florales y dulces que crean una esencia sofisticada y envolvente.\r\n\r\nNotas olfativas y su impacto en el aroma\r\n\r\nNotas de salida: Rosa y pimienta rosa.\r\nLa fragancia se abre con una combinación vibrante y especiada, donde la rosa aporta un matiz floral elegante y aterciopelado, mientras que la pimienta rosa añade un toque chispeante y ligeramente picante.\r\n\r\nNotas de corazón: Oud y ámbar.\r\nEn el corazón, el oud se manifiesta con su profundidad amaderada y ahumada, creando una sensación mística e intensa. El ámbar complementa con su calidez resinosa, aportando un carácter envolvente y sensual.\r\n\r\nNotas de fondo: Vainilla y madera.\r\nLa base es rica y reconfortante, con la dulzura cremosa de la vainilla que suaviza la composición, mientras que las notas amaderadas refuerzan la longevidad y la sofisticación del perfume.\r\n\r\n¿Cómo huele Badee Al Oud Amethyst?\r\n\r\nEl aroma de Badee Al Oud Amethyst es profundo, especiado y ligeramente dulce, con una salida floral y vibrante que se transforma en un corazón intenso y amaderado. A medida que evoluciona, la fragancia adquiere una calidez envolvente gracias al ámbar y la vainilla, dejando una impresión lujosa y seductora.",
                Price = 42000,
                IsOutstanding = true
              },

              new Product {
                Id = 2,
                BrandId = 2,
                Name = "Asad",
                DescriptionShort = "Amaderado con vainilla.",
                Price = 45000,
              },

              new Product {
                Id = 3,
                BrandId = 3,
                Name = "Ajwad",
                DescriptionShort = "Dulce, afrutado y romántico.",
                Price = 39000,
                IsOutstanding = true
              },

              new Product {
                Id = 4,
                BrandId = 1,
                Name = "Raghba Wood Intense",
                DescriptionShort = "Intenso, ahumado y elegante.",
                Price = 47000,
                IsOutstanding = true
              },

              new Product {
                Id = 5,
                BrandId = 2,
                Name = "Yara",
                DescriptionShort = "Suave, floral y moderno.",
                Price = 41000,
              },
              new Product {
                Id = 6,
                BrandId = 3,
                Name = "Kismet Angel",
                DescriptionShort = "Gourmand, dulce y sensual.",
                Price = 55000,
              },
              new Product {
                Id = 7,
                BrandId = 4,
                Name = "Barakkat Rouge 540",
                DescriptionShort = "Misterioso, almizclado y chic.",
                Price = 58000,
                IsOutstanding = true
              },
              new Product {
                Id = 8,
                BrandId = 5,
                Name = "Tobacco Touch",
                DescriptionShort = "Tábaco cálido y especiado.",
                Price = 52000,
              },
              new Product {
                Id = 9,
                BrandId = 4,
                Name = "Infini Oud",
                DescriptionShort = "Profundo y sofisticado.",
                Price = 60000,
              },
              new Product {
                Id = 10,
                BrandId = 6,
                Name = "Porto Neroli",
                DescriptionShort = "Fresco, cítrico y luminoso.",
                Price = 49000,
                IsOutstanding = true },
              new Product {
                Id = 11,
                BrandId = 7,
                Name = "The Lions",
                DescriptionShort = "exquisito bla bla bla",
                Price = 50000,
                },
              new Product {
                Id = 12,
                BrandId = 7,
                Name = "Oud for Glory",
                DescriptionShort = "Oriental, intenso y envolvente.",
                Price = 42000,
                IsOutstanding = true
              }
            ]);
        }
        private List<Category> GetCategoriesByIds(int[] categoryIds) {
            return _categories.Where(c => categoryIds.Contains(c.Id)).ToList();
        }
    }
}
