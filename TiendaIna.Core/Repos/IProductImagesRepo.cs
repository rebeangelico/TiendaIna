using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Repos {
    public interface IProductImagesRepo : ICrudRepo<ProductImage, int> {
        Task<(int id, int order)> CreateIfNotExists(int productId, int imageId);
        Task<IEnumerable<ProductImage>> GetByProductAsync(int productId);
    }
}
