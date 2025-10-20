using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IProductImagesService {

        #region Methods
        Task<ProductImageOutputModel> GetAsync(int id);
        IAsyncEnumerable<ProductImageOutputModel> GetAsync(int[] ids);
        Task<ProductImageOutputModel> Add(byte[] imageBytes, string mimeType);
        Task<ProductImageOutputModel> Add(string url);
        Task<ProductImageOutputModel> Update(int id, byte[] imageBytes, string mimeType);
        Task<ProductImageOutputModel> Update(int id, string url);
        Task Delete(int id);
        Task<SortedList<int, ProductImageOutputModel>> GetByProduct(int productId);
        Task MoveImage(int productImageId, int newIndex);
        #endregion

        #region Controller Methods
        Task<(byte[], string)?> GetBytesAsync(int id, ImageSize size = ImageSize.Default);
        #endregion

    }
}
