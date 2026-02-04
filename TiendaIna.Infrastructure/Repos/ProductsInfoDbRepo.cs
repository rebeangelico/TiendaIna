using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsInfoDbRepo : CrudDbRepoBase<ProductInfo, int>, IProductsInfoRepo
{
    public ProductsInfoDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task<IEnumerable<ProductInfo>> GetByOrder(int orderId) {
        using (var connection = CreateConnection())
        {
            return await connection.QueryAsync<ProductInfo>(
                p => p.OrderId == orderId
            );
        }
    }
}


