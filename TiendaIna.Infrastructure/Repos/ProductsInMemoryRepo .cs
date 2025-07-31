using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class ProductsInMemoryRepo : IProductsRepo {
        public void AddProduct(Product product) {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId) {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int productId) {
            return Task.FromResult(new Product() {
                Id = 1,
                Categories = new List<Category> { new Category { Id = 1, Name = "Perfumes Arabes" }, new Category {Id= 2, Name= "Perfumes Masculinos"} },
                Brand = new Brand() { Id = 1, Name = "Armaf" },
                Name = "The Lions",
                DescriptionMin = "exquisito bla bla bla",
                Imagen = "https://bestbrandsperfume.com/wp-content/uploads/2024/11/ARMAF-THE-LIONS-CLUB-RUGIR-3.4-Oz-Eau-De-Parfum-For-Men.png",
                Price = 50000,
                Gender = "Masculino"
            });
        }

        public Task<List<Product>> GetProductsAsync() {
            return Task.FromResult(new List<Product>
            {
              new Product {
                Id = 1,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Oud for Glory",
                DescriptionMin = "Oriental, intenso y envolvente.",
                Imagen = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/oudorflo-510777daeadf44959d17386008132208-1024-1024.webp",
                Price = 42000,
                Gender = "Unisex",
                IsOutstanding = true
              },

              new Product {
                Id = 2,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Asad",
                DescriptionMin = "Amaderado con un toque de vainilla.",
                Imagen = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/asad-d1a6c449c4071fd13017149465284044-1024-1024.webp",
                Price = 45000,
                Gender = "Masculino"
              },

              new Product {
                Id = 3,
                Categories = new List<Category> { new Category { Id = 1, Name = "Lattafa" } },
                Brand = new Brand { Id = 1, Name = "Lattafa" },
                Name = "Ajwad",
                DescriptionMin = "Dulce, afrutado y romántico.",
                Imagen = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/ddsaafs-f442ef5b7698b7af9e17399108474461-1024-1024.webp",
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
                Imagen = "https://mundoaromas.cl/cdn/shop/products/D_NQ_NP_968538-MLC47090611219_082021-O.jpg?v=1654892128",
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
                Imagen = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/yara-cde4579cb71070a8c617135640512548-1024-1024.webp",
                Price = 41000,
                Gender = "Femenino"
              },
              new Product {
                Id = 6,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Kismet Angel",
                DescriptionMin = "Gourmand, dulce y sensual.",
                Imagen = "https://images-cdn.ubuy.com.sa/65c2c9bdcb433f25857ba359-kismet-angel-by-maison-alhambra-eau-de.jpg",
                Price = 55000,
                Gender = "Femenino"
              },
              new Product {
                Id = 7,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Barakkat Rouge 540",
                DescriptionMin = "Misterioso, almizclado y chic.",
                Imagen = "https://images-cdn.ubuy.com.ar/68854594650a231ef40dbb7e-rouge-540-extrait-by-fragrance-world.jpg",
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
                Imagen = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/tobacco-touch-07921cf3cbce0d074617231426991171-1024-1024.webp",
                Price = 52000,
                Gender = "Masculino"
              },
              new Product {
                Id = 9,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Infini Oud",
                DescriptionMin = "Profundo, oriental y sofisticado.",
                Imagen = "https://orientaldream.b-cdn.net/3617-medium_default/maison-alhambra-infini-oud-joyous-edp-100ml.jpg",
                Price = 60000,
                Gender = "Unisex"
              },
              new Product {
                Id = 10,
                Categories = new List<Category> { new Category { Id = 2, Name = "Maison Alhambra" } },
                Brand = new Brand { Id = 2, Name = "Maison Alhambra" },
                Name = "Porto Neroli",
                DescriptionMin = "Fresco, cítrico y luminoso.",
                Imagen = "https://perfumescardales.com.ar/wp-content/uploads/2023/09/Fotos-pagina.pptx-24.jpg",
                Price = 49000,
                Gender = "Femenino",
                IsOutstanding = true
              }

            });
        }

        public void UpdateProduct(int productId) {
            throw new NotImplementedException();
        }
    }
}