using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IImagesRepo : ICrudRepo<Image, int> {
        Task<IEnumerable<Image>> GetByProductAsync(int productId);
        Task<Image?> GetByBrandAsync(int brandId);
    }
}
