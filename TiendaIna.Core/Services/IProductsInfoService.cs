using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IProductsInfoService
    {
        Task<List<ProductInfoModel>> GetAll();
        Task<ProductInfoModel> Get(int id);
        Task <List<ProductInfoModel>> GetFromOrder(int id);
        Task<int> Add(ProductInfoModel entity);
        Task Update(ProductInfoModel entity);
        Task Delete(int Id);
    }
}
