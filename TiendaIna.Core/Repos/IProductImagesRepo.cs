using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IProductImagesRepo : IRepo<ProductImage, int> {
        Task InsertIfNotExists(int productId, int imageId);
        Task Remove(int productId, int imageId);
        Task Move(int productId, int imageId, int position);
        Task SetAsCover(int productId, int imageId);
    }
}
