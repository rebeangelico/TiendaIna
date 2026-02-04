using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos;

public interface IProductsInfoRepo : ICrudRepo<ProductInfo, int> {
    Task<IEnumerable<ProductInfo>> GetByOrder(int orderId);
}