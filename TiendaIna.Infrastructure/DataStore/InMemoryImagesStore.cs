using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryImagesStore : IList<Image> { }

    public class InMemoryImagesStore : List<Image>, IInMemoryImagesStore {
        public InMemoryImagesStore() {
            Clear();
            AddRange([
              new Image {
                Id = 1,
                CdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/oudorflo-510777daeadf44959d17386008132208-1024-1024.webp",
                SmallCdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/oudorflo-510777daeadf44959d17386008132208-1024-1024.webp",
              },
              new Image {
                Id = 2,
                CdnUrl = "https://i.ebayimg.com/images/g/akEAAOSwfz9f-wtH/s-l1600.web",
                SmallCdnUrl = "https://i.ebayimg.com/images/g/akEAAOSwfz9f-wtH/s-l1600.web",
              },
              new Image {
                Id = 3,
                CdnUrl = "https://images-cdn.ubuy.com.ar/67d26db76b424b7fe204912b-oud-for-glory-bade-039-e-al-oud-lattafa.jp",
                SmallCdnUrl = "https://images-cdn.ubuy.com.ar/67d26db76b424b7fe204912b-oud-for-glory-bade-039-e-al-oud-lattafa.jp",
              },
              new Image {
                Id = 4,
                CdnUrl = "https://eclipseperfumes.cr/cdn/shop/products/375x500.64948.jpg?v=1680160661",
                SmallCdnUrl = "https://eclipseperfumes.cr/cdn/shop/products/375x500.64948.jpg?v=1680160661",
              },
              new Image {
                Id = 5,
                CdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/asad-d1a6c449c4071fd13017149465284044-1024-1024.webp",
                SmallCdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/asad-d1a6c449c4071fd13017149465284044-1024-1024.webp",
              },
              new Image {
                Id = 6,
                CdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/ddsaafs-f442ef5b7698b7af9e17399108474461-1024-1024.webp",
                SmallCdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/ddsaafs-f442ef5b7698b7af9e17399108474461-1024-1024.webp",
              },
              new Image {
                Id = 7,
                CdnUrl = "https://mundoaromas.cl/cdn/shop/products/D_NQ_NP_968538-MLC47090611219_082021-O.jpg?v=1654892128",
                SmallCdnUrl = "https://mundoaromas.cl/cdn/shop/products/D_NQ_NP_968538-MLC47090611219_082021-O.jpg?v=1654892128",
              },
              new Image {
                Id = 8,
                CdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/yara-cde4579cb71070a8c617135640512548-1024-1024.webp",
                SmallCdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/yara-cde4579cb71070a8c617135640512548-1024-1024.webp",
              },
              new Image {
                Id = 9,
                CdnUrl = "https://images-cdn.ubuy.com.sa/65c2c9bdcb433f25857ba359-kismet-angel-by-maison-alhambra-eau-de.jpg",
                SmallCdnUrl = "https://images-cdn.ubuy.com.sa/65c2c9bdcb433f25857ba359-kismet-angel-by-maison-alhambra-eau-de.jpg",
              },
              new Image {
                Id = 10,
                CdnUrl = "https://images-cdn.ubuy.com.ar/68854594650a231ef40dbb7e-rouge-540-extrait-by-fragrance-world.jpg",
                SmallCdnUrl = "https://images-cdn.ubuy.com.ar/68854594650a231ef40dbb7e-rouge-540-extrait-by-fragrance-world.jpg",
              },
              new Image {
                Id = 11,
                CdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/tobacco-touch-07921cf3cbce0d074617231426991171-1024-1024.webp",
                SmallCdnUrl = "https://acdn-us.mitiendanube.com/stores/004/407/494/products/tobacco-touch-07921cf3cbce0d074617231426991171-1024-1024.webp",
              },
              new Image {
                Id = 12,
                CdnUrl = "https://orientaldream.b-cdn.net/3617-medium_default/maison-alhambra-infini-oud-joyous-edp-100ml.jpg",
                SmallCdnUrl = "https://orientaldream.b-cdn.net/3617-medium_default/maison-alhambra-infini-oud-joyous-edp-100ml.jpg",
              },
              new Image {
                Id = 13,
                CdnUrl = "https://perfumescardales.com.ar/wp-content/uploads/2023/09/Fotos-pagina.pptx-24.jpg",
                SmallCdnUrl = "https://perfumescardales.com.ar/wp-content/uploads/2023/09/Fotos-pagina.pptx-24.jpg",
              },
              new Image {
                Id = 14,
                CdnUrl = "https://bestbrandsperfume.com/wp-content/uploads/2024/11/ARMAF-THE-LIONS-CLUB-RUGIR-3.4-Oz-Eau-De-Parfum-For-Men.png",
                SmallCdnUrl = "https://bestbrandsperfume.com/wp-content/uploads/2024/11/ARMAF-THE-LIONS-CLUB-RUGIR-3.4-Oz-Eau-De-Parfum-For-Men.png",
              },
              new Image {
                Id = 15,
                CdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/oudorflo-510777daeadf44959d17386008132208-1024-1024.webp",
                SmallCdnUrl = "https://dcdn-us.mitiendanube.com/stores/004/912/507/products/oudorflo-510777daeadf44959d17386008132208-1024-1024.webp",
              }
        ]);
        }
    }
}