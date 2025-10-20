
using Microsoft.Extensions.Options;
using RepoDb;
using RepoDb.Enumerations;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesDbRepo : CrudDbRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public Task<IEnumerable<ProductImage>> GetByProductAsync(int productId) => QueryAsync(pi => pi.ProductId == productId);
}


