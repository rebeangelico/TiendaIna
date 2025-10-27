using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;
public class ProductsService : IProductsService {
    #region fields
    private readonly IProductsRepo _productsRepo;
    private readonly ICategoriesService _categoriesService;

    private readonly IBrandsService _brandsService;
    private readonly IProductImagesService _productImagesService;
    #endregion

    #region constructors
    public ProductsService(IProductsRepo productsRepo, ICategoriesService categoriesService, IProductImagesService productImagesService, IBrandsService brandsService) {
        this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        this._categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        this._productImagesService = productImagesService ?? throw new ArgumentNullException(nameof(productImagesService));
        this._brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
    }
    #endregion

    #region Methods CRUD Products
    public async Task<List<ProductModel>> Get() {
        var products = await _productsRepo.GetAsync();
        var productModels = products.Select(p => ProductModel.FromEntity(p)).ToList();
        foreach (var product in productModels) {
            product.Categories = (await _categoriesService.GetByProductAsync(product.Id));
            product.Images = await _productImagesService.GetByProduct(product.Id);
            product.Brand= await _brandsService.Get(product.BrandId!.Value);
        }
        return productModels;
    }

    public async Task<ProductModel> Get(int productId) {
        var product = _productsRepo.GetAsync(productId).Result;
        var model = ProductModel.FromEntity(product);
        model.Categories = (await _categoriesService.GetByProductAsync(product.Id));
        model.Images = await _productImagesService.GetByProduct(productId);
        model.Brand = await _brandsService.Get(product.BrandId!.Value);
        return model;
    }

    public Task Delete(int productId) => _productsRepo.DeleteAsync(productId);

    public Task Update(ProductModel productModel) {
        var product = Product.FromModel(productModel);
        return _productsRepo.UpdateAsync(product);
    }
    
    public async Task<int> Add(ProductModel productModel) {
        var product = Product.FromModel(productModel);
        var id = await _productsRepo.CreateAsync(product);
        return id;
    }
    #endregion

    #region category handling
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync(int productId) => (await _categoriesService.GetByProductAsync(productId));

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) => _productsRepo.SetCategoriesAsync(productId, categoryIds);
    #endregion

}
