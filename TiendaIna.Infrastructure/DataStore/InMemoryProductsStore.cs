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
                Categories = GetCategoriesByIds([1, 2, 3]) ,
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Oud for Glory",
                DescriptionMin = "es una fragancia unisex profunda y misteriosa, con un equilibrio entre notas amaderadas, especiadas y dulces. Perfecta para quienes desean un aroma intenso, seductor y envolvente.",
                Description ="Es una fragancia unisex que pertenece a la familia olfativa ámbar amaderada, destacándose por su combinación de notas especiadas, florales y dulces que crean una esencia sofisticada y envolvente.\r\n\r\nNotas olfativas y su impacto en el aroma\r\n\r\nNotas de salida: Rosa y pimienta rosa.\r\nLa fragancia se abre con una combinación vibrante y especiada, donde la rosa aporta un matiz floral elegante y aterciopelado, mientras que la pimienta rosa añade un toque chispeante y ligeramente picante.\r\n\r\nNotas de corazón: Oud y ámbar.\r\nEn el corazón, el oud se manifiesta con su profundidad amaderada y ahumada, creando una sensación mística e intensa. El ámbar complementa con su calidez resinosa, aportando un carácter envolvente y sensual.\r\n\r\nNotas de fondo: Vainilla y madera.\r\nLa base es rica y reconfortante, con la dulzura cremosa de la vainilla que suaviza la composición, mientras que las notas amaderadas refuerzan la longevidad y la sofisticación del perfume.\r\n\r\n¿Cómo huele Badee Al Oud Amethyst?\r\n\r\nEl aroma de Badee Al Oud Amethyst es profundo, especiado y ligeramente dulce, con una salida floral y vibrante que se transforma en un corazón intenso y amaderado. A medida que evoluciona, la fragancia adquiere una calidez envolvente gracias al ámbar y la vainilla, dejando una impresión lujosa y seductora.",
                Image = 1,
                Images= {2,3,4},
                Price = 42000,
                Gender = "Unisex",
                IsOutstanding = true
              },

              new Product {
                Id = 2,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Asad",
                DescriptionMin = "Amaderado con vainilla.",
                Image = 5,
                Price = 45000,
                Gender = "Masculino"
              },

              new Product {
                Id = 3,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Ajwad",
                DescriptionMin = "Dulce, afrutado y romántico.",
                Image = 6,
                Price = 39000,
                Gender = "Femenino",
                IsOutstanding = true
              },

              new Product {
                Id = 4,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Raghba Wood Intense",
                DescriptionMin = "Intenso, ahumado y elegante.",
                Image = 7,
                Price = 47000,
                Gender = "Masculino",
                IsOutstanding = true
              },

              new Product {
                Id = 5,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Yara",
                DescriptionMin = "Suave, floral y moderno.",
                Image = 8,
                Price = 41000,
                Gender = "Femenino"
              },
              new Product {
                Id = 6,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Kismet Angel",
                DescriptionMin = "Gourmand, dulce y sensual.",
                Image = 9,
                Price = 55000,
                Gender = "Femenino"
              },
              new Product {
                Id = 7,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Barakkat Rouge 540",
                DescriptionMin = "Misterioso, almizclado y chic.",
                Image = 10,
                Price = 58000,
                Gender = "Unisex",
                IsOutstanding = true
              },
              new Product {
                Id = 8,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Tobacco Touch",
                DescriptionMin = "Tábaco cálido y especiado.",
                Image = 11,
                Price = 52000,
                Gender = "Masculino"
              },
              new Product {
                Id = 9,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Infini Oud",
                DescriptionMin = "Profundo y sofisticado.",
                Image = 12,
                Price = 60000,
                Gender = "Unisex"
              },
              new Product {
                Id = 10,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Porto Neroli",
                DescriptionMin = "Fresco, cítrico y luminoso.",
                Image = 13,
                Price = 49000,
                Gender = "Femenino",
                IsOutstanding = true },
              new Product {
                Id = 11,
                Categories = new List<Category> { new Category { Id = 1, Name = "Perfumes Arabes" }, new Category {Id= 2, Name= "Perfumes Masculinos"} },
                Brand = new Brand() { Id = 1, Name = "Armaf" },
                Name = "The Lions",
                DescriptionMin = "exquisito bla bla bla",
                Image = 14,
                Price = 50000,
                Gender = "Masculino"
                },
              new Product {
                Id = 12,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Oud for Glory",
                DescriptionMin = "Oriental, intenso y envolvente.",
                Image = 15,
                Price = 42000,
                Gender = "Unisex",
                IsOutstanding = true
              }
            ]);
        }
        private List<Category> GetCategoriesByIds(int[] categoryIds) {
            return _categories.Where(c => categoryIds.Contains(c.Id)).ToList();
        }
    }
}
