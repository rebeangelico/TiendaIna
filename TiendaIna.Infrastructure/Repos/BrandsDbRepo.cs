using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class BrandsDbRepo : CrudDbRepoBase<Brand, int>, IBrandsRepo {
    public BrandsDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

