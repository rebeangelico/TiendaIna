using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ImagesDbRepo : CrudDbRepoBase<Image, int>, IImagesRepo {
    public ImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task<Image?> GetByBrandAsync(int brandId) {
        var param = new Dictionary<string, object> {
            { nameof(brandId), brandId }
        };
        var result = await base.ExecuteQueryAsync("SELECT TOP(1) i.* " +
                                                  "FROM [dbo].[Images] i JOIN [dbo].[Brands] b " +
                                                  "ON i.Id = b.ImageId " +
                                                  "WHERE b.Id = @brandId", param);
        return result.FirstOrDefault();
    }

    public async Task<SortedList<int, Image>> GetByProductAsync(int productId) {
        var param = new Dictionary<string, object> {
            { nameof(productId), productId }
        };
        var orderedImages = await base.ExecuteQueryAsync<OrderedImage>("SELECT i.*, pi.OrderIndex " +
                                                                       "FROM [dbo].[Images] i JOIN [dbo].[ProductImages] pi " +
                                                                       "ON i.Id = pi.Id " +
                                                                       "WHERE pi.ProductId = @productId", param);
        var result = new SortedList<int, Image>();
        foreach (var orderedImage in orderedImages)
            result.Add(orderedImage.OrderIndex, orderedImage);
        return result;
    }
}

