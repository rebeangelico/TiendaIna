using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ImagesInMemoryRepo : InMemoryRepoBase<Image, int>, IImagesRepo {
    private readonly IInMemoryBrandsStore _brandsStore;
    private readonly IInMemoryProductImagesStore _productImagesStore;

    public ImagesInMemoryRepo(IInMemoryImagesStore imagesStore, IInMemoryBrandsStore brandsStore, IInMemoryProductImagesStore productImagesStore) : base(imagesStore) {
        _brandsStore = brandsStore ?? throw new ArgumentNullException(nameof(brandsStore));
        _productImagesStore = productImagesStore ?? throw new ArgumentNullException(nameof(productImagesStore));
    }

    public Task<Image?> GetByBrandAsync(int brandId) {
        var imageId = _brandsStore.SingleOrDefault(b => b.Id == brandId)?.ImageId;
        return Task.FromResult(_entities.SingleOrDefault(i => i.Id == imageId));
    }

    public Task<IEnumerable<Image>> GetByProductAsync(int productId) {
        var imageIds = _productImagesStore.Where(pi => pi.ProductId == productId).OrderBy(pi => pi.OrderIndex).Select(pi => pi.ImageId);
        return Task.FromResult(_entities.Where(i => imageIds.Contains(i.Id)));
    }
}