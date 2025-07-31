using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class ProductsRepo : InMemoryProductsRepo {
        public Product GetProductEL(int productId) {
            return new Product() {
                Id = 1,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand() { Id = 1, Name = "Armaf" },
                Name = "The Lions",
                Description = "exquisito bla bla bla",
                Imagen = "https://bestbrandsperfume.com/wp-content/uploads/2024/11/ARMAF-THE-LIONS-CLUB-RUGIR-3.4-Oz-Eau-De-Parfum-For-Men.png",
                Price = 50000,
                Gender = "Masculino"
            };
        }
        public List<Product> GetProductsEL() {
            return new List<Product>
            {
              new Product {
                Id = 1,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Oud for Glory",
                Description = "Oriental, intenso y envolvente.",
                Imagen = "https://fragstore.com/media/catalog/product/l/a/lattafa_oud_for_glory_100ml.jpg",
                Price = 42000,
                Gender = "Unisex",
                IsOutstanding = true
              },

              new Product {
                Id = 2,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Asad",
                Description = "Amaderado con un toque de vainilla.",
                Imagen = "https://fragstore.com/media/catalog/product/l/a/lattafa_asad.jpg",
                Price = 45000,
                Gender = "Masculino"
              },

              new Product {
                Id = 3,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Ajwad",
                Description = "Dulce, afrutado y romántico.",
                Imagen = "https://fragstore.com/media/catalog/product/l/a/lattafa_ajwad.jpg",
                Price = 39000,
                Gender = "Femenino",
                IsOutstanding = true
              },

              new Product {
                Id = 4,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Raghba Wood Intense",
                Description = "Intenso, ahumado y elegante.",
                Imagen = "https://fragstore.com/media/catalog/product/l/a/lattafa_raghba_wood_intense.jpg",
                Price = 47000,
                Gender = "Masculino",
                IsOutstanding = true
              },

              new Product {
                Id = 5,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Yara",
                Description = "Suave, floral y moderno.",
                Imagen = "https://fragstore.com/media/catalog/product/l/a/lattafa_yara_pink.jpg",
                Price = 41000,
                Gender = "Femenino"
              },
              new Product {
                Id = 6,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Kismet Angel",
                Description = "Gourmand, dulce y sensual.",
                Imagen = "https://alhambraperfumes.com/wp-content/uploads/2023/09/kismet-angel.jpg",
                Price = 55000,
                Gender = "Femenino"
              },
              new Product {
                Id = 7,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Barakkat Rouge 540",
                Description = "Misterioso, almizclado y chic.",
                Imagen = "https://alhambraperfumes.com/wp-content/uploads/2023/09/barakkat-540.jpg",
                Price = 58000,
                Gender = "Unisex",
                IsOutstanding = true
    },
              new Product {
                Id = 8,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Tobacco Touch",
                Description = "Tábaco cálido y especiado.",
                Imagen = "https://alhambraperfumes.com/wp-content/uploads/2023/09/tobacco-touch.jpg",
                Price = 52000,
                Gender = "Masculino"
              },
              new Product {
                Id = 9,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Infini Oud",
                Description = "Profundo, oriental y sofisticado.",
                Imagen = "https://alhambraperfumes.com/wp-content/uploads/2023/09/infini-oud.jpg",
                Price = 60000,
                Gender = "Unisex"
              },
              new Product {
                Id = 10,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Porto Neroli",
                Description = "Fresco, cítrico y luminoso.",
                Imagen = "https://alhambraperfumes.com/wp-content/uploads/2023/09/porto-neroli.jpg",
                Price = 49000,
                Gender = "Femenino",
                IsOutstanding = true
              }

            };
        }
    }
}