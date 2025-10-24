using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;
public class ProductsService : IProductsService {
    #region fields
    private readonly IProductsRepo _productsRepo;
    private readonly ICategoriesRepo _categoriesRepo;

    private readonly IProductImagesService _productImagesService;
    #endregion

    #region constructors
    public ProductsService(IProductsRepo productsRepo, ICategoriesRepo categoriesRepo, IProductImagesService productImagesService) {
        this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        this._categoriesRepo = categoriesRepo ?? throw new ArgumentNullException(nameof(categoriesRepo));
        this._productImagesService = productImagesService ?? throw new ArgumentNullException(nameof(productImagesService));
    }
    #endregion

    #region Methods CRUD Products
    public async Task<List<ProductModel>> Get() {
        var products = await _productsRepo.GetAsync();
        var productModels = products.Select(p => ProductModel.FromEntity(p)).ToList();
        foreach (var product in productModels) {
            product.Categories = (await _categoriesRepo.GetByProductAsync(product.Id)).Select(c => CategoryModel.FromEntity(c)).ToList();
            product.Images = await _productImagesService.GetByProduct(product.Id);
        }
        return productModels;
    }

    public async Task<ProductModel> Get(int productId) {
        var product = _productsRepo.GetAsync(productId).Result;
        var model = ProductModel.FromEntity(product);
        model.Categories = (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c)).ToList();
        model.Images = await _productImagesService.GetByProduct(productId);
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
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync(int productId) => (await _categoriesRepo.GetByProductAsync(productId)).Select(c => CategoryModel.FromEntity(c));

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) => _productsRepo.SetCategoriesAsync(productId, categoryIds);
    #endregion

}
