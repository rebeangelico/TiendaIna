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

    public Task<SortedList<int, Image>> GetByProductAsync(int productId) {
        var productImages = _productImagesStore.Where(pi => pi.ProductId == productId);
        var result = new SortedList<int, Image>();
        foreach (var productImage in productImages) {
            var image = _entities.SingleOrDefault(i => i.Id == productImage.ImageId);
            if (image is null) continue;
            result.Add(productImage.OrderIndex, image);
        }
        return Task.FromResult(result);
    }
}