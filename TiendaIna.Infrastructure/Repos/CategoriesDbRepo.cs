using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class CategoriesDbRepo : CrudDbRepoBase<Category, int>, ICategoriesRepo {
    public CategoriesDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public Task<IEnumerable<Category>> GetByProductAsync(int productId) {
        var param = new Dictionary<string, object> {
            { nameof(productId), productId }
        };
        return base.ExecuteQueryAsync("SELECT c.* " +
                                      "FROM [Categories] c INNER JOIN [ProductsCategories] pc " +
                                      "ON c.[Id] = pc.[CategoryId] " +
                                      "WHERE ProductId = @productId " +
                                      "ORDER BY c.Name", param);
    }
}

