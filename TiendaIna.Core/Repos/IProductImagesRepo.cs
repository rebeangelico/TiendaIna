using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Repos {
    public interface IProductImagesRepo : ICrudRepo<ProductImage, int> {
        Task<IEnumerable<ProductImage>> GetByProductAsync(int productId);
    }
}
