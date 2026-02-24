using System.Collections.Generic;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class ProductsInfoService : IProductsInfoService
{
    private readonly IProductsInfoRepo _productsInfoRepo;

    public ProductsInfoService(IProductsInfoRepo productsInfoRepo) {
        this._productsInfoRepo = productsInfoRepo ?? throw new ArgumentNullException(nameof(productsInfoRepo));
    }

    public Task<int> Add(ProductInfoModel entity) {
        var Entity = ProductInfo.FromModel(entity);
        return _productsInfoRepo.CreateAsync(Entity);
    }

    public Task<int> Add(ProductModel entity, int quantity)
    {
        var x = new ProductInfoModel() {IdProduct = entity.Id , Name = entity.Name , Price = entity.Price, Quantity = quantity };

        var Entity = ProductInfo.FromModel(x);
        return _productsInfoRepo.CreateAsync(Entity);
    }



    public Task Delete(int Id) {
        return _productsInfoRepo.DeleteAsync(Id);
    }


    public async Task<ProductInfoModel> Get(int id) {
        var productInfo = await _productsInfoRepo.GetAsync(id);
        var model = ProductInfoModel.FromEntity(productInfo);
        return model;
    }

    public async Task<List<ProductInfoModel>> GetAll() {
        var productsInfo = await _productsInfoRepo.GetAsync();
        var models = productsInfo.Select(p => ProductInfoModel.FromEntity(p)).ToList();
        return models;
    }

    public async Task<List<ProductInfoModel>> GetFromOrder(int orderId){
        var models = new List<ProductInfoModel>();
        var productsInfo = await _productsInfoRepo.GetByOrder(orderId);

        foreach (var pi in productsInfo) {
            var model = ProductInfoModel.FromEntity(pi);
            models.Add(model);
        }
        return models;
    }

    public Task Update(ProductInfoModel entity)
    {
        throw new NotImplementedException();
    }
}

