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

    public Task<int> Add(ProductInfoModel entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductInfoModel> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductInfoModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductInfoModel>> GetFromOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductInfoModel entity)
    {
        throw new NotImplementedException();
    }
}

