using Azure.Core.GeoJson;
using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesDbRepo : DbRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task InsertIfNotExists(int productId, int imageId) {

        if (await base.ExistsAsync(pi => pi.ProductId == productId && pi.ImageId == imageId))
            return;

        var oIndex = (int)(await base.CountAsync(pi => pi.ProductId == productId))+1;
        await base.InsertAsync(new ProductImage { ProductId = productId, ImageId = imageId, OrderIndex = oIndex });
    }
    public async Task Remove(int productId, int imageId) {
        var exists = await base.ExistsAsync(pi => pi.ProductId == productId && pi.ImageId == imageId);
        if (!exists)
            throw new ArgumentException("Esta relación no existe.");

        await base.DeleteAsync(pi => pi.ProductId == productId && pi.ImageId == imageId);
    }

    public async Task Move(int productId, int imageId, int position) {
        var param = new Dictionary<string, object> {
            { nameof(productId), productId }
        };
        var imagesFromProduct = (await base.ExecuteQueryAsync(
                "SELECT * FROM [ProductImages] WHERE ProductId = @productId", param))
                .OrderBy(i => i.OrderIndex)
                .ToList();

        var relation = imagesFromProduct.FirstOrDefault(i => i.ImageId == imageId);
        if (relation == null) return;

        imagesFromProduct.Remove(relation);
        await base.DeleteAsync(relation);

        imagesFromProduct.Insert(position, relation);

        for (int i = 0; i < imagesFromProduct.Count; i++) {
            var image = imagesFromProduct[i];
            image.OrderIndex = i;
            await base.UpdateAsync(image);
        }
    }
    public async Task SetAsCover(int productId, int imageId) {
        var param = new Dictionary<string, object> {
            { nameof(productId), productId }
        };
        var imagesFromProduct = (await base.ExecuteQueryAsync("SELECT * FROM[ProductImages] WHERE ProductId = @productId", param));
        var element = imagesFromProduct.FirstOrDefault(i => i.ImageId == imageId);
        if (element == null) return;

        foreach (var image in imagesFromProduct) { 
            if (image.ImageId == imageId)
                image.IsCover = true;
            else
                image.IsCover = false;
            }
        await base.UpdateAllAsync(imagesFromProduct);
    }
}


