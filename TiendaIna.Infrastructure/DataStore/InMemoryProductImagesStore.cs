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
                OrderIndex= 1,
                CdnUrl="https://plazza.pk/wp-content/uploads/2023/09/Badee-Al-Oud-Lattafa.webp", 
                SmallCdnUrl="https://plazza.pk/wp-content/uploads/2023/09/Badee-Al-Oud-Lattafa.webp",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 2,
                ProductId = 1,
                OrderIndex= 2,
                CdnUrl="https://tse1.mm.bing.net/th/id/OIP.Xfxy1d621qRuxLIfPKBKWgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3", 
                SmallCdnUrl="https://tse1.mm.bing.net/th/id/OIP.Xfxy1d621qRuxLIfPKBKWgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 3,
                ProductId = 1,
                OrderIndex= 3,
                CdnUrl="https://assets.beautyhub.co.ke/wp-content/uploads/2024/07/02224240/lattafa-badee-al-oud-oud-for-glory-eau-de-parfum-100ml-5.jpg",
                SmallCdnUrl="https://assets.beautyhub.co.ke/wp-content/uploads/2024/07/02224240/lattafa-badee-al-oud-oud-for-glory-eau-de-parfum-100ml-5.jpg",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 4,
                ProductId = 2,
                OrderIndex= 1,
                CdnUrl="https://perfumesdelolimpo.com/wp-content/uploads/2023/10/Honor-Glory-1.png",
                SmallCdnUrl="https://perfumesdelolimpo.com/wp-content/uploads/2023/10/Honor-Glory-1.png",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 5,
                ProductId = 2,
                OrderIndex= 2,
                CdnUrl="https://perfumes.ec/cdn/shop/files/LattafaBade_eAlOudHonor_Glory100ml.png?v=1711400964",
                SmallCdnUrl="https://perfumes.ec/cdn/shop/files/LattafaBade_eAlOudHonor_Glory100ml.png?v=1711400964",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 6,
                ProductId = 2,
                OrderIndex= 3,
                CdnUrl="https://http2.mlstatic.com/D_Q_NP_2X_721835-MLA82846885024_032025-E.webp",
                SmallCdnUrl="https://http2.mlstatic.com/D_Q_NP_2X_721835-MLA82846885024_032025-E.webp",
                Data= [],
                SmallData = [],
                MimeType="image/png"
              },
              new ProductImage {
                Id = 7,
                ProductId = 3,
                OrderIndex= 1,
                CdnUrl="https://gelniche.fbitsstatic.net/img/p/perfume-ajwad-lattafa-unissex-eau-de-parfum-60ml-74178/260787-2.jpg?w=800&h=800&v=no-change&qs=ignore",
                SmallCdnUrl="https://gelniche.fbitsstatic.net/img/p/perfume-ajwad-lattafa-unissex-eau-de-parfum-60ml-74178/260787-2.jpg?w=800&h=800&v=no-change&qs=ignore",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 8,
                ProductId = 3,
                OrderIndex= 2,
                CdnUrl="https://th.bing.com/th/id/R.ebe6cf4e7c62880424ade1b19dac95ad?rik=quoarZF4%2bnDFWQ&riu=http%3a%2f%2fperfumesreal.com%2fcdn%2fshop%2ffiles%2fLATTAFAAJWADUNISEXEDP60ML.png%3fv%3d1714776635&ehk=5cw1ptzTVXufK2b4UlECnARgsAfHvj2WMkSbPQBs3e4%3d&risl=&pid=ImgRaw&r=0",
                SmallCdnUrl="https://th.bing.com/th/id/R.ebe6cf4e7c62880424ade1b19dac95ad?rik=quoarZF4%2bnDFWQ&riu=http%3a%2f%2fperfumesreal.com%2fcdn%2fshop%2ffiles%2fLATTAFAAJWADUNISEXEDP60ML.png%3fv%3d1714776635&ehk=5cw1ptzTVXufK2b4UlECnARgsAfHvj2WMkSbPQBs3e4%3d&risl=&pid=ImgRaw&r=0",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 9,
                ProductId = 3,
                OrderIndex= 3,
                CdnUrl="https://i.pinimg.com/736x/3d/cf/34/3dcf349947ff512b650c3476a4a3c2a4.jpg",
                SmallCdnUrl="https://i.pinimg.com/736x/3d/cf/34/3dcf349947ff512b650c3476a4a3c2a4.jpg",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 10,
                ProductId = 4,
                OrderIndex= 1,
                CdnUrl="https://tse2.mm.bing.net/th/id/OIP.oxkjY7H3zZIOtItEaeiJFgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                SmallCdnUrl="https://tse2.mm.bing.net/th/id/OIP.oxkjY7H3zZIOtItEaeiJFgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 110,
                ProductId = 4,
                OrderIndex= 2,
                CdnUrl="https://tse2.mm.bing.net/th/id/OIP.5PnPLNUfzGyLIlULGY7WywHaIO?rs=1&pid=ImgDetMain&o=7&rm=3",
                SmallCdnUrl="https://tse2.mm.bing.net/th/id/OIP.5PnPLNUfzGyLIlULGY7WywHaIO?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 11,
                ProductId = 5,
                OrderIndex= 1,
                CdnUrl="https://m.media-amazon.com/images/I/61wF0YAAIvL._SL1423_.jpg",
                SmallCdnUrl="https://m.media-amazon.com/images/I/61wF0YAAIvL._SL1423_.jpg",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 12,
                ProductId = 6,
                OrderIndex= 1,
                CdnUrl="https://www.intenseoud.com/cdn/shop/files/Untitleddesign-2023-05-10T132510.974.png?v=1683743275",
                SmallCdnUrl="https://www.intenseoud.com/cdn/shop/files/Untitleddesign-2023-05-10T132510.974.png?v=1683743275",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 13,
                ProductId = 7,
                OrderIndex= 1,
                CdnUrl="https://tse4.mm.bing.net/th/id/OIP.8gznom6JfRO5Z7_cB_miSQHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                SmallCdnUrl="https://tse4.mm.bing.net/th/id/OIP.8gznom6JfRO5Z7_cB_miSQHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 14,
                ProductId = 8,
                OrderIndex= 1,
                CdnUrl="https://cdn.shopify.com/s/files/1/1833/7915/products/Tobacco-Touch-Perfume-Eau-De-Parfum-by-Maison-Alhambra-Lattafa-Inspired-by-Tobacco-Vanilla-Tom-Ford-2.jpg?v=1679667762",
                SmallCdnUrl="https://cdn.shopify.com/s/files/1/1833/7915/products/Tobacco-Touch-Perfume-Eau-De-Parfum-by-Maison-Alhambra-Lattafa-Inspired-by-Tobacco-Vanilla-Tom-Ford-2.jpg?v=1679667762",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 15,
                ProductId = 9,
                OrderIndex= 1,
                CdnUrl="https://kingdomfragrances.com/cdn/shop/files/Infini-Oud-Perfume-_-Eau-De-Parfum-by-Maison-Alhambra-_-Lattafa-Inspired-by-Initio-Oud-For-Greatness.webp?v=1682642897",
                SmallCdnUrl="https://kingdomfragrances.com/cdn/shop/files/Infini-Oud-Perfume-_-Eau-De-Parfum-by-Maison-Alhambra-_-Lattafa-Inspired-by-Initio-Oud-For-Greatness.webp?v=1682642897",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 16,
                ProductId = 10,
                OrderIndex= 1,
                CdnUrl="https://tse2.mm.bing.net/th/id/OIP.yQ3BNanVxXaEwKGfIPJm_AHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                SmallCdnUrl="https://tse2.mm.bing.net/th/id/OIP.yQ3BNanVxXaEwKGfIPJm_AHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 17,
                ProductId = 11,
                OrderIndex= 1,
                CdnUrl="https://tse2.mm.bing.net/th/id/OIP.Dkb97dloAOW_RbmTAhhtPgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                SmallCdnUrl="https://tse2.mm.bing.net/th/id/OIP.Dkb97dloAOW_RbmTAhhtPgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 18,
                ProductId = 12,
                OrderIndex= 1,
                CdnUrl="https://i5.walmartimages.com/seo/Lattafa-Asad-by-Lattafa-Eau-De-Parfum-Spray-Unisex-3-4-oz-for-Women_14382b33-503a-4d0c-8702-ebb0ab126c60.4faaaceca0aee403b5e450d21b4330a3.jpeg",
                SmallCdnUrl="https://i5.walmartimages.com/seo/Lattafa-Asad-by-Lattafa-Eau-De-Parfum-Spray-Unisex-3-4-oz-for-Women_14382b33-503a-4d0c-8702-ebb0ab126c60.4faaaceca0aee403b5e450d21b4330a3.jpeg",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
               }
        ]);
        }
    }
}