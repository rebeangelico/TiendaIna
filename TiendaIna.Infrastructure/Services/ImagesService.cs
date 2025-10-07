using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class ImagesService : IImagesService {
    private readonly IImagesRepo _imagesRepo;
    public ImagesService(IImagesRepo imagesRepo) {
        this._imagesRepo = imagesRepo ?? throw new ArgumentNullException(nameof(imagesRepo));
    }

    public async Task<ImageModel> Add(byte[] imageBytes, string mimeType) {
        var image = new Core.Entities.Image() { Data = imageBytes, SmallData = imageBytes, MimeType = mimeType };
        await _imagesRepo.CreateAsync(image);
        return new ImageModel() {
            Id = image.Id,
            Url = !string.IsNullOrWhiteSpace(image.CdnUrl) ? image.CdnUrl : $"images/{image.Id}",
            SmallUrl = !string.IsNullOrWhiteSpace(image.SmallCdnUrl) ? image.SmallCdnUrl : $"images/{image.Id}?size=s",
        };
    }

    public async Task<ImageModel> Add(string url) {
        var image = new Core.Entities.Image() { CdnUrl = url, SmallCdnUrl = url };
        await _imagesRepo.CreateAsync(image);
        return new ImageModel() {
             Id = image.Id,
             Url = image.CdnUrl,
             SmallUrl = image.SmallCdnUrl,
        };
    }

    public Task<ImageModel> GetAsync(int id, ImageSize size = ImageSize.Default) {
        throw new NotImplementedException();
    }

    public async Task<(byte[], string)?> GetBytesAsync(int id, ImageSize size = ImageSize.Default) {
        var img = await _imagesRepo.GetAsync(id);
        if(img is null)
            return null;
        return (size == ImageSize.Small ? (img.SmallData, img.MimeType) : (img.Data, img.MimeType))!;
    }

    public Task<ImageModel> Update(int id, Stream stream, string mimeType) {
        throw new NotImplementedException();
    }

    public Task<ImageModel> Update(int id, string url) {
        throw new NotImplementedException();
    }

    public Task Delete(int Id) => _imagesRepo.DeleteAsync(Id);
}

