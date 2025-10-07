using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IImagesService {
        Task<ImageModel> GetAsync(int id, ImageSize size = ImageSize.Default);
        Task<(byte[], string)?> GetBytesAsync(int id, ImageSize size = ImageSize.Default);
        Task<ImageModel> Add(byte[] imageBytes, string mimeType);
        Task<ImageModel> Add(string url);
        Task<ImageModel> Update(int id, byte[] imageBytes, string mimeType, ImageSize size = ImageSize.Default);
        Task<ImageModel> Update(int id, string url, ImageSize size = ImageSize.Default);
        Task Delete(int id);
    }
}
