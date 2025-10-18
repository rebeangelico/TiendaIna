using Microsoft.Extensions.Options;
using RepoDb;
using RepoDb.Enumerations;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesDbRepo : CrudDbRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task<(int id, int order)> CreateIfNotExists(int productId, int imageId) {
        var param = new Dictionary<string, object> {
            { nameof(productId), productId },
            { nameof(imageId), imageId }
        };

        IEnumerable<Field> orderIndexField = Field.Parse<ProductImage>(pi => new { pi.OrderIndex });

        var relationQueryResult = await QueryAsync(pi => pi.ProductId == productId && pi.ImageId == imageId, orderIndexField, top: 1);

        if (relationQueryResult?.Any() is true) {
            var productImage = relationQueryResult.First();
            return (id: productImage.Id, order: productImage.OrderIndex);
        }

        int? index = await base.MaxAsync<int?>(orderIndexField.First(), pi => pi.ProductId == productId);
        if (index is null)
            index = 0;
        else
            index++;

        int productImageId;
        try {
            productImageId = (int)await base.InsertAsync<ProductImage>(new() { ProductId = productId, ImageId = imageId, OrderIndex = index.Value });
        } catch (Exception ex) {
            throw new InvalidOperationException("The product or the image do not exists.", ex);
        }

        return (id: productImageId, order: index.Value);
    }

    public Task<IEnumerable<ProductImage>> GetByProductAsync(int productId) => QueryAsync(pi => pi.ProductId == productId);
}


