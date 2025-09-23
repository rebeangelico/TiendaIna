using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;
public class ProductsService : IProductsService {

    private readonly IProductsRepo _productsRepo;
    public ProductsService(IProductsRepo productsRepo) {
        this._productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
    }

    public async Task<List<ProductModel>> GetAll() {
        var products = await _productsRepo.GetAllAsync();
        var models = products.Select(p => new ProductModel(p)).ToList();
        return models;
    }

    public Task<ProductModel> Get(int productId) {
        var product = _productsRepo.GetAsync(productId).Result;
        var model = new ProductModel(product);
        return Task.FromResult(model);
    }

    public Task Delete(int productId) => _productsRepo.DeleteAsync(productId);

    public Task Update(ProductModel productModel) {
        var product = new Product(productModel);
        return _productsRepo.UpdateAsync(product);
    }
    public Task Add(ProductModel productModel) {
        var product = new Product(productModel);
        return _productsRepo.CreateAsync(product);
    }

    public async Task<IEnumerable<int>> GetCategoriesIds(int productId) {
        var product = await _productsRepo.GetAsync(productId);
        return product.IdsCategories;
    }

}
