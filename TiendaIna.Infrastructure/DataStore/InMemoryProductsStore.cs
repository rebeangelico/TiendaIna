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
                Stock=2,
                Name = "Oud for Glory",
                DescriptionShort = "Un perfume árabe intenso y elegante, dominado por el oud y especias cálidas, que transmite fuerza y distinción.",
                Description =
                            "Es una fragancia oriental amaderada que se ha convertido en un referente dentro de los perfumes árabes de lujo.\n" +
                            "- Notas de salida: azafrán picante y nuez moscada terrosa, que aportan un inicio cálido y especiado.\n" +
                            "- Notas de corazón: lavanda y pachulí, que equilibran la intensidad con un toque fresco y herbal.\n" +
                            "- Notas de fondo: oud profundo, almizcle y cuero, que le dan carácter, misterio y una fijación prolongada.\n\n" +
                            "Características principales:\n" +
                            "- Tipo: Eau de Parfum.\n" +
                            "- Tamaño: 100 mL.\n" +
                            "- Origen: Emiratos Árabes Unidos.\n" +
                            "- Acordes dominantes: oud, cálido especiado, amaderado, cuero, almizclado.\n" +
                            "- Duración: alta fijación, permanece muchas horas en piel y ropa.\n" +
                            "- Estilo: sofisticado, misterioso, ideal para la noche o eventos especiales.\n\n" +
                            "📌 Perfil del usuario ideal:\n" +
                            "- Personas que disfrutan de perfumes intensos y orientales.\n" +
                            "- Quienes buscan una fragancia única y llamativa, diferente a los perfumes comerciales.\n" +
                            "- Perfecto para ocasiones formales o momentos donde se quiere dejar huella.\n\n" +
                            "👉 Este perfume es muy popular entre quienes aman el oud porque combina lo exótico con lo elegante. Es fuerte, pero equilibrado, y suele ser comparado con fragancias nicho de alto valor.",
                Price = 42000,
                IsVisible = true
              },

              new Product {
                Id = 2,
                BrandId = 2,
                Name = "Al Oud Honor & Glory",
                Stock = 3,
                IsVisible= true,
                DescriptionShort= "Una fragancia árabe elegante y moderna, con notas frescas y amaderadas que transmiten sofisticación y energía",
                Description = "Asaad de Lattafa Perfumes es un perfume oriental amaderado pensado para quienes buscan un aroma versátil, refinado y con buena presencia.\r\n- Notas de salida: cítricos brillantes y especias suaves, que aportan frescura y vitalidad desde el primer instante.\r\n- Notas de corazón: lavanda y maderas aromáticas, que equilibran la energía con un toque elegante y masculino.\r\n- Notas de fondo: oud ligero, ámbar y almizcle, que le dan profundidad, calidez y una fijación prolongada.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: cítrico, amaderado, especiado, almizclado.\r\n- Duración: alta fijación, permanece varias horas en piel y ropa.\r\n- Estilo: moderno, elegante, ideal para uso diario o eventos especiales.\r\n",
                Price = 45000,
              },

              new Product {
                Id = 3,
                BrandId = 3,
                Stock=2,
                Name = "Ajwad",
                DescriptionShort= "Una fragancia árabe dulce y envolvente, con notas frutales y amaderadas que transmiten calidez y sofisticación",
                Description = "Ajwad de Lattafa Perfumes es un perfume oriental frutal-amaderado que combina lo exótico con lo moderno, ideal para quienes buscan un aroma llamativo pero equilibrado.\r\n- Notas de salida: frutas rojas y cítricos brillantes, que aportan frescura y dulzura inicial.\r\n- Notas de corazón: rosa y flores blancas, que añaden un toque romántico y elegante.\r\n- Notas de fondo: oud suave, almizcle y ámbar, que le dan profundidad, calidez y una fijación prolongada.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: frutal, floral, amaderado, almizclado.\r\n- Duración: buena fijación, permanece varias horas en piel y ropa.\r\n- Estilo: dulce, sofisticado, ideal para la noche o momentos especiales.\r\n\r\n📌 Perfil del usuario ideal\r\n- Personas que disfrutan de perfumes dulces y envolventes con un toque oriental.\r\n- Quienes buscan una fragancia romántica y elegante, con presencia pero sin ser demasiado intensa.\r\n- Perfecto para eventos sociales, cenas o salidas nocturnas.\r\n\r\n👉 Rebeca, Ajwad es muy buscado porque logra un balance entre lo frutal y lo oriental, con un oud suave que lo hace más fácil de usar que otros perfumes árabes más intensos.\r\n¿Querés que te prepare también la descripción corta y detallada de Khamrah, que es otro de los más populares de Lattafa?\r\n",
                Price = 39000,
                IsVisible = true
              },

              new Product {
                Id = 4,
                BrandId = 1,
                Name = "Raghba Wood Intense",
                Stock=2,
                DescriptionShort = "Un perfume intenso y amaderado, con notas de oud, vainilla y especias que transmiten fuerza y sofisticación",
                Description = "Es una fragancia oriental amaderada muy popular por su carácter profundo y envolvente. Es una versión más intensa y oscura del clásico Raghba, pensada para quienes disfrutan de aromas potentes y duraderos.\r\n- Notas de salida: incienso y especias cálidas, que aportan un inicio misterioso y penetrante.\r\n- Notas de corazón: oud, sándalo y maderas nobles, que refuerzan la sensación de elegancia y poder.\r\n- Notas de fondo: vainilla, ámbar y almizcle, que suavizan la intensidad con un toque dulce y cálido.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: amaderado, oud, cálido especiado, vainilla, ámbar.\r\n- Duración: excelente fijación, permanece muchas horas en piel y ropa.\r\n- Estilo: intenso, sofisticado, ideal para la noche o climas fríos.\r\n\r\n📌 Perfil del usuario ideal\r\n- Personas que disfrutan de perfumes fuertes y orientales, con gran presencia.\r\n- Quienes buscan una fragancia única y llamativa, que deje huella.\r\n- Perfecto para eventos nocturnos, ocasiones especiales o uso en invierno.\r\n\r\n👉 Rebeca, este perfume es considerado uno de los más representativos de Lattafa en el estilo árabe intenso. Es dulce pero poderoso, y suele ser elegido por quienes quieren destacar con un aroma diferente.\r\n¿Querés que te arme también la descripción de Khamrah, que es otro de los más buscados y comparado con perfumes nicho de alta gama?\r\n",
                Price = 47000,
                IsVisible = true
              },

              new Product {
                Id = 5,
                BrandId = 2,
                Name = "Yara Pink",
                Stock=2,
                DescriptionShort = "Una fragancia femenina, dulce y delicada, con notas frutales y cremosas que transmiten ternura y frescura.",
                Description = "Es un perfume oriental frutal-floral que se destaca por su carácter juvenil, alegre y encantador. Es la versión más suave y romántica de la línea Yara, ideal para quienes buscan un aroma dulce pero ligero.\r\n- Notas de salida: frutas tropicales y cítricos brillantes, que aportan frescura y vitalidad.\r\n- Notas de corazón: flores blancas y rosa, que añaden un toque delicado y femenino.\r\n- Notas de fondo: vainilla cremosa, almizcle y sándalo, que suavizan la fragancia con calidez y elegancia.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: frutal, floral, dulce, cremoso, almizclado.\r\n- Duración: moderada a alta, ideal para uso diario.\r\n- Estilo: romántico, juvenil, perfecto para primavera y verano.\r\n",
                Price = 41000,
                IsVisible = true
              },
              new Product {
                Id = 6,
                BrandId = 3,
                Name = "Kismet Angel",
                Stock=2,
                DescriptionShort = "Fragancia dulce y sofisticada, con notas gourmand y orientales que transmiten elegancia y sensualidad.",
                Description ="Kismet Angel de Maison Alhambra (marca perteneciente al grupo Lattafa) es un perfume oriental gourmand que se ha ganado gran popularidad por su carácter dulce, envolvente y lujoso. Es considerado una alternativa accesible a fragancias nicho de alta gama.\r\n- Notas de salida: miel y caramelo, que aportan un inicio cálido, dulce y adictivo.\r\n- Notas de corazón: vainilla y haba tonka, que refuerzan la sensación cremosa y gourmand.\r\n- Notas de fondo: oud suave, ámbar y almizcle, que equilibran la dulzura con profundidad y fijación prolongada.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: dulce, gourmand, vainilla, ámbar, amaderado.\r\n- Duración: excelente fijación, permanece muchas horas en piel y ropa.\r\n- Estilo: sofisticado, sensual, ideal para la noche o climas fríos.\r\n\r\n📌 Perfil del usuario ideal\r\n- Personas que disfrutan de perfumes dulces y lujosos, con un aire gourmand.\r\n- Quienes buscan una fragancia sofisticada y sensual, que destaque en ocasiones especiales.\r\n- Perfecto para eventos nocturnos, cenas románticas o momentos donde se quiere dejar huella.\r\n\r\n👉 Rebeca, Kismet Angel es muy buscado porque ofrece un perfil gourmand intenso y elegante, con una calidad que suele compararse con perfumes nicho mucho más costosos.\r\n¿Querés que te prepare también la descripción de Khamrah, que es otro de los más populares de Lattafa y muy solicitado en Argentina?\r\n",
                Price = 55000,
                IsVisible = true
              },
              new Product {
                Id = 7,
                BrandId = 4,
                Name = "Barakkat Rouge 540",
                DescriptionShort = "Fragancia lujosa y envolvente, con notas dulces y ambaradas que transmiten elegancia y sofisticación.",
                Description ="Es un perfume oriental ambarado inspirado en el famoso Baccarat Rouge 540 de Maison Francis Kurkdjian. Se caracteriza por su aroma dulce, cálido y refinado, que combina lo moderno con lo clásico.\r\n- Notas de salida: azafrán y jazmín, que aportan un inicio especiado y floral.\r\n- Notas de corazón: ámbar gris y maderas nobles, que añaden profundidad y elegancia.\r\n- Notas de fondo: resinas, almizcle y un toque dulce, que crean un final envolvente y duradero.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: ambarado, dulce, especiado, floral, almizclado.\r\n- Duración: excelente fijación, permanece muchas horas en piel y ropa.\r\n- Estilo: sofisticado, elegante, ideal para ocasiones especiales.\r\n\r\n📌 Perfil del usuario ideal\r\n- Personas que disfrutan de perfumes dulces y ambarados, con un aire de lujo.\r\n- Quienes buscan una fragancia sofisticada y llamativa, que deje huella.\r\n- Perfecto para eventos nocturnos, cenas elegantes o momentos especiales.\r\n\r\n👉 Rebeca, este perfume es muy buscado porque ofrece un perfil similar al de un perfume nicho de alta gama, pero a un precio mucho más accesible. Es intenso, elegante y deja una estela inolvidable.\r\n¿Querés que te prepare también la descripción de Khamrah, que suele ser comparado con perfumes nicho gourmand y es uno de los más vendidos de Lattafa?\r\n",
                Price = 58000,
                IsVisible = true
              },
              new Product {
                Id = 8,
                BrandId = 5,
                Name = "Tobacco Touch",
                Stock = 2,
                DescriptionShort = "Una fragancia cálida y sofisticada, con notas de tabaco, especias y dulzura que transmiten elegancia y carácter.",
                Description ="Tobacco Touch de Maison Alhambra es un perfume oriental especiado que combina la fuerza del tabaco con acordes dulces y amaderados, logrando un aroma envolvente y seductor. Es considerado una alternativa accesible a perfumes nicho de estilo similar.\r\n- Notas de salida: especias cálidas y un toque cítrico, que aportan energía y frescura inicial.\r\n- Notas de corazón: tabaco intenso y vainilla cremosa, que crean un contraste entre lo fuerte y lo dulce.\r\n- Notas de fondo: cacao, frutos secos, ámbar y maderas, que refuerzan la profundidad y la fijación prolongada.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: tabaco, cálido especiado, dulce, amaderado, ámbar.\r\n- Duración: excelente fijación, permanece muchas horas en piel y ropa.\r\n- Estilo: elegante, seductor, ideal para la noche o climas fríos.\r\n",
                Price = 52000,
                IsVisible = true
              },
              new Product {
                Id = 9,
                BrandId = 4,
                Name = "Infini Oud",
                Stock= 3,
                DescriptionShort = "Un perfume profundo y sofisticado, con oud y especias que transmiten carácter y distinción.",
                Description ="Infini Oud de Maison Alhambra (grupo Lattafa) es un Eau de Parfum de 100 ml que pertenece a la familia ámbar amaderada/especiada. Se caracteriza por su aroma intenso y envolvente, ideal para quienes buscan un perfume con personalidad fuerte y duradera.\r\n- Notas de salida: azafrán, lavanda y nuez moscada → aportan un inicio especiado y ligeramente fresco.\r\n- Notas de corazón: madera de oud (agarwood) y pachulí → refuerzan la profundidad y el carácter oriental.\r\n- Notas de fondo: almizcle, vetiver y madera ambarina → añaden calidez, elegancia y fijación prolongada.\r\nCaracterísticas principales\r\n- Tipo: Eau de Parfum.\r\n- Tamaño: 100 ml.\r\n- Origen: Emiratos Árabes Unidos.\r\n- Acordes dominantes: oud, especiado cálido, amaderado, almizclado.\r\n- Duración: excelente fijación, permanece muchas horas en piel y ropa.\r\n- Estilo: intenso, sofisticado, ideal para la noche o climas fríos.\r\n\r\n📌 Perfil del usuario ideal\r\n- Personas que disfrutan de perfumes orientales intensos y especiados.\r\n- Quienes buscan una fragancia unisex con carácter fuerte y elegante.\r\n- Perfecto para eventos nocturnos, ocasiones especiales o uso en invierno.\r\n\r\n👉 Rebeca, Infini Oud es muy buscado porque ofrece un perfil olfativo profundo y misterioso, con un oud protagonista que lo hace destacar frente a otros perfumes árabes. Es versátil (unisex) y deja una estela elegante y duradera.\r\n¿Querés que te prepare también la descripción de Khamrah, que es uno de los más vendidos de Lattafa y suele ser comparado con perfumes nicho gourmand?\r\n",
                Price = 60000,
                IsVisible = true
              },
              new Product {
                Id = 10,
                BrandId = 6,
                Name = "Porto Neroli",
                DescriptionShort = "Un perfume cítrico y marino, inspirado en la frescura mediterránea, que transmite vitalidad y sofisticación.",
                Description = "Es un perfume oriental cítrico inspirado en la frescura mediterránea.\n" +
                                "- Notas de salida: neroli, limón, mandarina y jazmín.\n" +
                                "- Notas de corazón: flor de azahar, lavanda y sal marina.\n" +
                                "- Notas de fondo: hierbas aromáticas, ámbar y ajenjo.\n\n" +
                                "Características principales:\n" +
                                "- Tipo: Eau de Parfum.\n" +
                                "- Tamaño: 80 mL.\n" +
                                "- Origen: Emiratos Árabes Unidos.\n" +
                                "- Acordes dominantes: cítrico, floral blanco, marino, herbal, ambarado.\n" +
                                "- Duración: moderada.\n" +
                                "- Estilo: fresco, elegante, ideal para primavera y verano.\n\n" +
                                "📌 Perfil del usuario ideal:\n" +
                                "- Personas que disfrutan de perfumes frescos y cítricos.\n" +
                                "- Quienes buscan una fragancia versátil y ligera.\n" +
                                "- Perfecto para uso diario y climas cálidos.",
                Price = 49000,
                IsVisible = true },

              new Product {
                Id = 11,
                BrandId = 7,
                Name = "Rugir The Lions Club",
                Stock= 3,
                DescriptionShort = "Una fragancia intensa y sofisticada, con especias y maderas que transmiten fuerza y carácter.",
                Description = "Es un perfume intenso y sofisticado que transmite fuerza y carácter.\n" +
                                "- Notas de salida: especias cálidas y cítricos.\n" +
                                "- Notas de corazón: maderas nobles y flores aromáticas.\n" +
                                "- Notas de fondo: oud, ámbar y almizcle.\n\n" +
                                "Características principales:\n" +
                                "- Tipo: Eau de Parfum.\n" +
                                "- Tamaño: 100 mL.\n" +
                                "- Origen: Emiratos Árabes Unidos.\n" +
                                "- Acordes dominantes: especiado, amaderado, oud, almizclado.\n" +
                                "- Duración: alta fijación.\n" +
                                "- Estilo: elegante, poderoso, ideal para la noche.\n\n" +
                                "📌 Perfil del usuario ideal:\n" +
                                "- Personas que disfrutan de perfumes intensos y orientales.\n" +
                                "- Quienes buscan una fragancia llamativa y con presencia.\n" +
                                "- Perfecto para ocasiones especiales.",
                Price = 50000,
                IsVisible = true
                },
              new Product {
                Id = 12,
                BrandId = 7,
                Name = "Asaad",
                Stock= 4,
                DescriptionShort = "Un perfume oriental amaderado, con oud y especias que transmiten elegancia y distinción.",
                Description = "Es una fragancia oriental amaderada que celebra la fuerza y la sofisticación.\n" +
                                "- Notas de salida: azafrán y especias cálidas.\n" +
                                "- Notas de corazón: lavanda, pachulí y maderas nobles.\n" +
                                "- Notas de fondo: oud profundo, ámbar y almizcle.\n\n" +
                                "Características principales:\n" +
                                "- Tipo: Eau de Parfum.\n" +
                                "- Tamaño: 100 mL.\n" +
                                "- Origen: Emiratos Árabes Unidos.\n" +
                                "- Acordes dominantes: oud, cálido especiado, amaderado, almizclado.\n" +
                                "- Duración: excelente fijación.\n" +
                                "- Estilo: sofisticado, misterioso, ideal para la noche.\n\n" +
                                "📌 Perfil del usuario ideal:\n" +
                                "- Personas que disfrutan de perfumes intensos y orientales.\n" +
                                "- Quienes buscan una fragancia única y elegante.\n" +
                                "- Perfecto para ocasiones formales o momentos especiales.",
                Price = 42000,
                IsVisible = true
              }
            ]);
        }
        private List<Category> GetCategoriesByIds(int[] categoryIds) {
            return _categories.Where(c => categoryIds.Contains(c.Id)).ToList();
        }
    }
}
