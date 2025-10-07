using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesDbRepo : DbRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public Task InsertIfNotExists(int productId, int imageId) => throw new NotImplementedException();
    public Task Remove(int productId, int imageId) => throw new NotImplementedException();
    public Task Move(int productId, int imageId, int position) => throw new NotImplementedException();
    public Task SetAsCover(int productId, int imageId) => throw new NotImplementedException();
}

