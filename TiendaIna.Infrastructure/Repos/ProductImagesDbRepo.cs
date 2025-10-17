using Azure.Core.GeoJson;
using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesDbRepo : CrudDbRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task CreateIfNotExists(int productId, int imageId) {

        if (await base.ExistsAsync<ProductImage>(pi => pi.ProductId == productId && pi.ImageId == imageId))
            return;

        var oIndex = (int)(await base.CountAsync<ProductImage>(pi => pi.ProductId == productId))+1;
        await base.InsertAsync(new ProductImage { ProductId = productId, ImageId = imageId, OrderIndex = oIndex });
    }
}


