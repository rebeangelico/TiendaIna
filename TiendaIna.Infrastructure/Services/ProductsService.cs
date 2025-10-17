using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;
public class ProductsService : IProductsService {
    #region fields
    private readonly IProductsRepo _productsRepo;
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IImagesRepo _imagesRepo;
    private readonly IProductImagesRepo _productImagesRepo;
    #endregion

    #region constructors
    public ProductsService(IProductsRepo productsRepo, ICategoriesRepo categoriesRepo, IImagesRepo imagesRepo, IProductImagesRepo productImagesRepo) {
        this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        this._categoriesRepo = categoriesRepo ?? throw new ArgumentNullException(nameof(categoriesRepo));
        this._imagesRepo = imagesRepo ?? throw new ArgumentNullException(nameof(imagesRepo));
        this._productImagesRepo = productImagesRepo ?? throw new ArgumentNullException(nameof(productImagesRepo));
    }
    #endregion

    public async Task<List<ProductModel>> Get() {
        var products = await _productsRepo.GetAsync();
        var models = products.Select(p => ProductModel.FromEntity(p)).ToList();
        return models;
    }

    public async Task<ProductModel> Get(int productId) {
        var product = _productsRepo.GetAsync(productId).Result;
        var model = ProductModel.FromEntity(product);
        model.Categories = (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c)).ToList();
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

    #region category handling
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync(int productId) => (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c));

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) => _productsRepo.SetCategoriesAsync(productId, categoryIds);
    #endregion

    #region image handling
    public async Task<SortedList<int, ImageModel>> GetImages(int productId) {
        var productImages = await _imagesRepo.GetByProductAsync(productId);
        var result = new SortedList<int, ImageModel>();
        foreach (var pi in productImages) {
            var imageModel = new ImageModel() {
                Id = pi.Value.Id,
                Url = !string.IsNullOrWhiteSpace(pi.Value.CdnUrl) ? pi.Value.CdnUrl : $"https://localhost/images/{pi.Value.Id}",
                SmallUrl = !string.IsNullOrWhiteSpace(pi.Value.SmallCdnUrl) ? pi.Value.SmallCdnUrl : $"https://localhost/images/{pi.Value.Id}?size=s",
            };
            result.Add(pi.Key, imageModel);
        }
        return result;
    }
    public async Task AddImage(int productId, int imageId) => await _productImagesRepo.CreateIfNotExists(productId, imageId);
    public async Task RemoveImage(int productImageId) => await _productImagesRepo.DeleteAsync(productImageId);
    public async Task MoveImage(int productImageId, int position) {
        throw new NotImplementedException();
    }
    #endregion
}
