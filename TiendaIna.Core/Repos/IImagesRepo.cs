using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface IImagesRepo : ICrudRepo<Image, int> {
        Task<SortedList<int, Image>> GetByProductAsync(int productId);
        Task<Image?> GetByBrandAsync(int brandId);
    }
}
