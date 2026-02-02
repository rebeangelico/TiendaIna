using Microsoft.Extensions.Options;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsInfoDbRepo : CrudDbRepoBase<ProductInfo, int>, IProductsInfoRepo
{
    public ProductsInfoDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

}

