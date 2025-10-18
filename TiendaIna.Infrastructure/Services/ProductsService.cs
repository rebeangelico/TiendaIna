using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;
public class ProductsService : IProductsService {
    #region fields
    private readonly IProductsRepo _productsRepo;
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IProductImagesRepo _productImagesRepo;

    private readonly IImagesService _imagesService;
    #endregion

    #region constructors
    public ProductsService(IProductsRepo productsRepo, ICategoriesRepo categoriesRepo, IProductImagesRepo productImagesRepo, IImagesService imagesService) {
        this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        this._categoriesRepo = categoriesRepo ?? throw new ArgumentNullException(nameof(categoriesRepo));
        this._productImagesRepo = productImagesRepo ?? throw new ArgumentNullException(nameof(productImagesRepo));

        this._imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
    }
    #endregion

    #region Methods CRUD Products
    public async Task<List<ProductModel>> Get() {
        var products = await _productsRepo.GetAsync();
        var models = products.Select(p => ProductModel.FromEntity(p)).ToList();
        return models;
    }

    public async Task<ProductModel> Get(int productId) {
        var product = _productsRepo.GetAsync(productId).Result;
        var model = ProductModel.FromEntity(product);
        model.Categories = (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c)).ToList();
        model.Images = await GetImages(productId);
        return model;
    }

    public Task Delete(int productId) => _productsRepo.DeleteAsync(productId);

    public Task Update(ProductModel productModel) {
        var product = Product.FromModel(productModel);
        return _productsRepo.UpdateAsync(product);
    }
    
    public Task Add(ProductModel productModel) {
        var product = Product.FromModel(productModel);
        return _productsRepo.CreateAsync(product);
    }
    #endregion

    #region category handling
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync(int productId) => (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c));

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) => _productsRepo.SetCategoriesAsync(productId, categoryIds);
    #endregion

    #region image handling
    public async Task<SortedList<int, ProductImageModel>> GetImages(int productId) {
        var productImages = await _productImagesRepo.GetByProductAsync(productId);
        var productImageIds = productImages.Select(pi => pi.ImageId);
        var results = new SortedList<int, ProductImageModel>();
        await foreach (var imageModel in _imagesService.GetAsync(productImageIds.ToArray())) {
            var productImage = productImages.Single(pi => pi.ImageId == imageModel.Id);
            var id = productImage.Id;
            var ix = productImage.OrderIndex;
            var productImageModel = new ProductImageModel() {
                Id = id,
                ImageId = imageModel.Id,
                Url = !string.IsNullOrWhiteSpace(imageModel.Url) ? imageModel.Url : $"https://localhost/images/{imageModel.Id}",
                SmallUrl = !string.IsNullOrWhiteSpace(imageModel.SmallUrl) ? imageModel.SmallUrl : $"https://localhost/images/{imageModel.Id}?size=s",
                OrderIndex = ix
            };
            results.Add(ix, productImageModel);
        }
        return results;
    }
    public async Task RemoveImage(int productImageId) => await _productImagesRepo.DeleteAsync(productImageId);
    public async Task MoveImage(int productImageId, int newIndex) {
        var productImage = await _productImagesRepo.GetAsync(productImageId);
        var productImagesList = (await _productImagesRepo.GetByProductAsync(productImage.ProductId)).OrderBy(pi => pi.OrderIndex);

        var minIndex = productImagesList.Min(pi => pi.OrderIndex);
        var maxIndex = productImagesList.Max(pi => pi.OrderIndex);
        int currentIndex = productImage.OrderIndex;

        if (productImage == null)
            throw new ArgumentNullException(nameof(productImage));

        if (newIndex == currentIndex || newIndex < 0 || newIndex < minIndex || newIndex > maxIndex)
            return;

        var targetProductImage = productImagesList.FirstOrDefault(pi => pi.OrderIndex == newIndex);

        // Caso 1: Intercambio directo
        if (Math.Abs(newIndex - currentIndex) == 1 && targetProductImage != null) {
            targetProductImage.OrderIndex = currentIndex;
            productImage.OrderIndex = newIndex;

            await _productImagesRepo.UpdateAsync(targetProductImage);
            await _productImagesRepo.UpdateAsync(productImage);
        }
        // Caso 2: Posición libre
        else if (targetProductImage == null) {
            productImage.OrderIndex = newIndex;
            await _productImagesRepo.UpdateAsync(productImage);
        }
        // Caso 3: Reemplazo y desplazamiento
        else {
            // Desplazar imágenes entre newPosition y currentPosition
            if (newIndex < currentIndex) {
                foreach (var img in productImagesList.Where(pi => pi.OrderIndex >= newIndex && pi.OrderIndex < currentIndex)) {
                    img.OrderIndex++;
                    await _productImagesRepo.UpdateAsync(img);
                }
            } else {
                foreach (var img in productImagesList.Where(pi => pi.OrderIndex > currentIndex && pi.OrderIndex <= newIndex)) {
                    img.OrderIndex--;
                    await _productImagesRepo.UpdateAsync(img);
                }
            }

            productImage.OrderIndex = newIndex;
            await _productImagesRepo.UpdateAsync(productImage);
        }
    }
    public async Task<KeyValuePair<int, ProductImageModel>> AddImage(int productId, int imageId) {
        var relationIdAndOrder = await _productImagesRepo.CreateIfNotExists(productId, imageId);
        var image = await _imagesService.GetAsync(imageId);
        var productImageModel = new ProductImageModel() { Id = relationIdAndOrder.id, ImageId = imageId, Url = image.Url, SmallUrl = image.SmallUrl, OrderIndex = relationIdAndOrder.order };
        return new KeyValuePair<int, ProductImageModel>(relationIdAndOrder.order, productImageModel);
    }
    #endregion

}
