using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class ProductsDbRepo : DbRepoBase<Category, int>, ICategoriesRepo {
    public ProductsDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

