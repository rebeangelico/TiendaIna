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
    #region Methods
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

    public async Task<ImageModel> GetAsync(int id, ImageSize size = ImageSize.Default) {
        var image = await _imagesRepo.GetAsync(id);
        if (image.CdnUrl == null && image.SmallCdnUrl == null) {
            return new ImageModel { Id = image.Id, Url = $"images/{image.Id}", SmallUrl = "images/{image.Id}?size=s" };
        } else {
            return new ImageModel { Id = image.Id, Url = image.CdnUrl, SmallUrl = image.SmallCdnUrl };
        }
    }

    public async Task<ImageModel> Update(int id, byte[] imageBytes, string mimeType, ImageSize size = ImageSize.Default) {
        var image = await _imagesRepo.GetAsync(id);
        if (image == null) return null;

        image.MimeType = mimeType;

        if (size != null && size != ImageSize.Default)
            image.SmallData = imageBytes;
        else
            image.Data = imageBytes;

        await _imagesRepo.UpdateAsync(image);

        return new ImageModel {
            Id = image.Id,
            Url = image.CdnUrl,
            SmallUrl = image.SmallCdnUrl
        };
    }

    public async Task<ImageModel> Update(int id, string url, ImageSize size = ImageSize.Default) {
        var image = await _imagesRepo.GetAsync(id);
        if (image == null) return null;

        if (size != null && size != ImageSize.Default)
            image.SmallCdnUrl = url;
        else
            image.CdnUrl = url;

        await _imagesRepo.UpdateAsync(image);

        return new ImageModel {
            Id = image.Id,
            Url = image.CdnUrl,
            SmallUrl = image.SmallCdnUrl
        };
    }

    public Task Delete(int Id) => _imagesRepo.DeleteAsync(Id);
    #endregion

    #region Method Bytes (controller)
    public async Task<(byte[], string)?> GetBytesAsync(int id, ImageSize size = ImageSize.Default) {
        var img = await _imagesRepo.GetAsync(id);
        if(img is null)
            return null;
        return (size == ImageSize.Small ? (img.SmallData, img.MimeType) : (img.Data, img.MimeType))!;
    }
    #endregion
}

