using TiendaIna.Core.Entities;

namespace TiendaIna.Web.Razor.Data {
    public static class DbInitializer {

        public static void Initialize(TiendaInaWebRazorContext contex) {

            if (contex.Brands.Any()) {
                return;
            }
            var brands = new Brand[] {
                new Brand {Name="Lattafa"},
                new Brand {Name="Maison Alambra"}
            };
            contex.Brands.AddRange(brands);
            contex.SaveChanges();



            var categories = new Category[] {
                new Category {
                    Name="Perfumes Arabes"},
                new Category {
                    Name="Perfumes Nacionales"},
                new Category {
                    Name="Perfumes Femeninos", ParentCategoryId=1}
            };
            contex.Categories.AddRange(categories);
            contex.SaveChanges();



            var products = new Product[] {
                new Product {Name="Her Confesion",
                            idBrand=contex.Brands.First(b => b.Name=="Lattafa").Id,
                            Description="Her Confession de Lattafa es un perfume femenino con una mezcla cautivadora de notas. La apertura destaca por canela y acordes místicos, mientras que el corazón presenta jazmín y nardo. El fondo combina haba tonka, almizcle y vainilla. Ideal para mujeres que irradian confianza y misterio",
                            Price=60000,
                            Imagen="https://perfumeoriental.com/cdn/shop/files/Perfume-mujer-Her-Confession-100ml-Lattafa-Perfume-Oriental.webp?v=1738581096&width=1946"
                            ,Categories= contex.Categories.ToList()
                },
                new Product {Name="Khamrra",
                            idBrand=contex.Brands.First(b => b.Name=="Lattafa").Id,
                            Description="El perfume Khamrra de Lattafa es una fragancia aromática especiada lanzada en 2022. Sus notas de salida incluyen canela, nuez moscada y bergamota. Es una fragancia exótica y seductora que se presenta en una elegante botella de 100 ml",
                            Price=80000,
                            Imagen="https://tse3.mm.bing.net/th/id/OIP.Brq456BYeC1xj8AF3GEFdgHaFT?rs=1&pid=ImgDetMain&o=7&rm=3"
                            ,Categories= contex.Categories.ToList()
                            }
            };
            contex.Products.AddRange(products);
            contex.SaveChanges();


        }
    }
}
