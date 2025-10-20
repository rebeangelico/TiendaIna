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

    public override Task<int> CreateAsync(Image entity) {
        entity.Id = Random.Shared.Next(1, 100);
        return base.CreateAsync(entity);
    }
}