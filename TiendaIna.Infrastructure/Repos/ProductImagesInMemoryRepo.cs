using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class ProductImagesInMemoryRepo : InMemoryRepoBase<ProductImage, int>, IProductImagesRepo {
    public ProductImagesInMemoryRepo(IInMemoryProductImagesStore brandsStore) : base(brandsStore) { }

    public Task CreateIfNotExists(int productId, int imageId) {
        var productImages = _entities.Where(pi => pi.ProductId == productId);
        var productImage = productImages.SingleOrDefault(pi => pi.ImageId == imageId);
        if(productImage is not null)
             return Task.CompletedTask;
        var orderix = productImages.Max(pi => pi.OrderIndex) + 1;
        _entities.Add(new() {
            Id = Random.Shared.Next(1, 100000),
            ProductId = productId,
            ImageId = imageId,
            OrderIndex = orderix
        });
        return Task.CompletedTask;
    }

    public Task Remove(int productId, int imageId) {
        var productImage = _entities.SingleOrDefault(pi => pi.ProductId == productId && pi.ImageId == imageId);
        if(productImage is null)
            throw new InvalidOperationException();
        _entities.Remove(productImage);
        return Task.CompletedTask;
    }

    public Task Move(int productId, int imageId, int position) {
        var productImages = _entities.Where(pi => pi.ProductId == productId).OrderBy(pi => pi.OrderIndex).ToList();
        if (productImages?.Any() is not true)
            throw new InvalidOperationException();

        var positionIndex = productImages.FindIndex(pi => pi.OrderIndex == position);

        var productImage = productImages.SingleOrDefault(pi => pi.ImageId == imageId);
        if(productImage is null)
            throw new InvalidOperationException();

        if (positionIndex >= 0) {
            _entities.Remove(productImage);
            _entities.Insert(positionIndex - 1, productImage);
        } else {
            _entities.Remove(productImage);
            _entities.Insert(position, productImage);
        }

        for (int i=0; i < productImages.Count; i++)
            productImages[i].OrderIndex = i;

        return Task.CompletedTask;
    }
}