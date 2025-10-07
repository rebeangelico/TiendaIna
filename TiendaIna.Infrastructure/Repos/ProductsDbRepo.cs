using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsDbRepo : CrudDbRepoBase<Product, int>, IProductsRepo {
    public ProductsDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public Task SetCategoriesAsync(int productId, IEnumerable<int> categoryIds) {
        var sql = "INSERT INTO ProductsCategories (ProductId, CategoryId) VALUES ";
        foreach(var catId in categoryIds)
            sql += $"({productId}, {catId}),";
        sql = sql.TrimEnd(',');
        sql += ";";
        return base.ExecuteNonQueryAsync(sql);
    }
}

