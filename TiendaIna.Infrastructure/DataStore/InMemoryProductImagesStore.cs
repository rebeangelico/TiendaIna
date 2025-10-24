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
                CdnUrl="https://nuochoarosa.com/wp-content/uploads/2020/10/142198_img-7506-lattafa-bade-e-al-oud-oud-for-glory_720.jpg", 
                SmallCdnUrl="https://nuochoarosa.com/wp-content/uploads/2020/10/142198_img-7506-lattafa-bade-e-al-oud-oud-for-glory_720.jpg",
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
                CdnUrl="https://diamhijab.com/wp-content/uploads/2024/08/IMG-20240809-WA0017.jpg",
                SmallCdnUrl="https://diamhijab.com/wp-content/uploads/2024/08/IMG-20240809-WA0017.jpg",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 9,
                ProductId = 3,
                OrderIndex= 3,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 10,
                ProductId = 4,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
              new ProductImage {
                Id = 11,
                ProductId = 5,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 12,
                ProductId = 6,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 13,
                ProductId = 7,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 14,
                ProductId = 8,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
                new ProductImage {
                Id = 15,
                ProductId = 9,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 16,
                ProductId = 10,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 17,
                ProductId = 11,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              },
               new ProductImage {
                Id = 18,
                ProductId = 12,
                OrderIndex= 1,
                CdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                SmallCdnUrl="https://perfumepalace.in/cdn/shop/files/Lattafa-Khamrah_grande.jpg?v=1707736680",
                Data= [],
                SmallData = [],
                MimeType="image/jpeg"
              }
        ]);
        }
    }
}