using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductImagesRepo : ICrudRepo<ProductImage, int> {
        Task CreateIfNotExists(int productId, int imageId);
    }
}
