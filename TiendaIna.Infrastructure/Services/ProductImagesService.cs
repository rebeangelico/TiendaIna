using TiendaIna.Core;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class ProductImagesService : IProductImagesService {
    private readonly IProductImagesRepo _productImagesRepo;
    public ProductImagesService(IProductImagesRepo productImagesRepo) {
        this._productImagesRepo = productImagesRepo ?? throw new ArgumentNullException(nameof(productImagesRepo));
    }
    #region Methods
    public async Task<ProductImageOutputModel> Add(byte[] imageBytes, string mimeType) {
        var productImage = new Core.Entities.ProductImage() { Data = imageBytes, SmallData = imageBytes, MimeType = mimeType };
        await _productImagesRepo.CreateAsync(productImage);
        return new ProductImageOutputModel() {
            Id = productImage.Id,
            ProductId = productImage.ProductId,
            Url = !string.IsNullOrWhiteSpace(productImage.CdnUrl) ? productImage.CdnUrl : $"images/{productImage.Id}",
            SmallUrl = !string.IsNullOrWhiteSpace(productImage.SmallCdnUrl) ? productImage.SmallCdnUrl : $"images/{productImage.Id}?size=s",
            OrderIndex = productImage.OrderIndex,
        };
    }

    public async Task<ProductImageOutputModel> Add(string url) {
        var productImage = new Core.Entities.ProductImage() { CdnUrl = url, SmallCdnUrl = url };
        await _productImagesRepo.CreateAsync(productImage);
        return new ProductImageOutputModel() {
             Id = productImage.Id,
             ProductId = productImage.ProductId,
             Url = productImage.CdnUrl,
             SmallUrl = productImage.SmallCdnUrl,
             OrderIndex = productImage.OrderIndex,
        };
    }

    public async Task<ProductImageOutputModel> GetAsync(int id) {
        var image = await _productImagesRepo.GetAsync(id);
        if (image.CdnUrl == null && image.SmallCdnUrl == null) {
            return new ProductImageOutputModel { Id = image.Id, ProductId= image.ProductId , Url = $"images/{image.Id}", SmallUrl = "images/{image.Id}?size=s", OrderIndex=image.OrderIndex };
        } else {
            return new ProductImageOutputModel { Id = image.Id,ProductId= image.ProductId , Url = image.CdnUrl, SmallUrl = image.SmallCdnUrl, OrderIndex = image.OrderIndex };
        }
    }

    public async IAsyncEnumerable<ProductImageOutputModel> GetAsync(int[] ids) {
        var images = await _productImagesRepo.GetAsync(ids);
        foreach (var image in images) {
            if (image.CdnUrl == null && image.SmallCdnUrl == null) {
                yield return new ProductImageOutputModel { Id = image.Id, ProductId= image.ProductId, Url = $"images/{image.Id}", SmallUrl = "images/{image.Id}?size=s", OrderIndex = image.OrderIndex };
            } else {
                yield return new ProductImageOutputModel { Id = image.Id, ProductId=image.ProductId , Url = image.CdnUrl, SmallUrl = image.SmallCdnUrl , OrderIndex= image.OrderIndex };
            }
        }
    }

    public async Task<ProductImageOutputModel> Update(int id, byte[] imageBytes, string mimeType) {
        var productImage = await _productImagesRepo.GetAsync(id);
        if (productImage == null) return null;

        productImage.MimeType = mimeType;

        productImage.Data = imageBytes;
        productImage.SmallData = imageBytes;

        await _productImagesRepo.UpdateAsync(productImage);

        return new ProductImageOutputModel {
            Id = productImage.Id,
            ProductId = productImage.ProductId,
            Url = productImage.CdnUrl,
            SmallUrl = productImage.SmallCdnUrl,
            OrderIndex = productImage.OrderIndex,
        };
    }

    public async Task<ProductImageOutputModel> Update(int id, string url) {
        var productImage = await _productImagesRepo.GetAsync(id);
        if (productImage == null) throw new FileNotFoundException();

        productImage.SmallCdnUrl = url;
        productImage.CdnUrl = url;

        await _productImagesRepo.UpdateAsync(productImage);

        return new ProductImageOutputModel {
            Id = productImage.Id,
            ProductId = productImage.ProductId,
            Url = productImage.CdnUrl,
            SmallUrl = productImage.SmallCdnUrl,
            OrderIndex = productImage.OrderIndex
        };
    }

    public Task Delete(int Id) => _productImagesRepo.DeleteAsync(Id);

    public async Task MoveImage(int productImageId, int newIndex) {
        var productImage = await _productImagesRepo.GetAsync(productImageId);
        var productImagesList = (await _productImagesRepo.GetByProductAsync(productImage.ProductId)).OrderBy(pi => pi.OrderIndex);

        var minIndex = productImagesList.Min(pi => pi.OrderIndex);
        var maxIndex = productImagesList.Max(pi => pi.OrderIndex);
        int currentIndex = productImage.OrderIndex;

        if (productImage == null)
            throw new ArgumentNullException(nameof(productImage));

        if (newIndex == currentIndex || newIndex < 0 || newIndex < minIndex || newIndex > maxIndex)
            return;

        var targetProductImage = productImagesList.FirstOrDefault(pi => pi.OrderIndex == newIndex);

        if (Math.Abs(newIndex - currentIndex) == 1 && targetProductImage != null) {
            targetProductImage.OrderIndex = currentIndex;
            productImage.OrderIndex = newIndex;

            await _productImagesRepo.UpdateAsync(targetProductImage);
            await _productImagesRepo.UpdateAsync(productImage);
        } else if (targetProductImage == null) {
            productImage.OrderIndex = newIndex;
            await _productImagesRepo.UpdateAsync(productImage);
        } else {
            if (newIndex < currentIndex) {
                foreach (var img in productImagesList.Where(pi => pi.OrderIndex >= newIndex && pi.OrderIndex < currentIndex)) {
                    img.OrderIndex++;
                    await _productImagesRepo.UpdateAsync(img);
                }
            } else {
                foreach (var img in productImagesList.Where(pi => pi.OrderIndex > currentIndex && pi.OrderIndex <= newIndex)) {
                    img.OrderIndex--;
                    await _productImagesRepo.UpdateAsync(img);
                }
            }

            productImage.OrderIndex = newIndex;
            await _productImagesRepo.UpdateAsync(productImage);
        }
    }
    #endregion

    #region Method Bytes (controller)
    public async Task<(byte[], string)?> GetBytesAsync(int id, ImageSize size = ImageSize.Default) {
        var img = await _productImagesRepo.GetAsync(id);
        if(img is null)
            return null;
        return (size == ImageSize.Small ? (img.SmallData, img.MimeType) : (img.Data, img.MimeType))!;
    }

    public async Task<SortedList<int, ProductImageOutputModel>> GetByProduct(int productId) {
        var productImages = await _productImagesRepo.GetByProductAsync(productId);
        var results = new SortedList<int, ProductImageOutputModel>();
        foreach (var productImage in productImages) {
            var id = productImage.Id;
            var ix = productImage.OrderIndex;
            var productImageModel = new ProductImageOutputModel() {
                Id = id,
                ProductId = productImage.ProductId,
                Url = !string.IsNullOrWhiteSpace(productImage.CdnUrl) ? productImage.CdnUrl : $"https://localhost/images/{productImage.Id}",
                SmallUrl = !string.IsNullOrWhiteSpace(productImage.SmallCdnUrl) ? productImage.SmallCdnUrl : $"https://localhost/images/{productImage.Id}?size=s",
                OrderIndex = productImage.OrderIndex,
            };
            results.Add(ix, productImageModel);
        }
        return results;
    }

    #endregion
}

