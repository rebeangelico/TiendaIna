using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class BrandsInMemoryRepo : InMemoryRepoBase<Brand, int>, IBrandsRepo {
    public BrandsInMemoryRepo(IInMemoryBrandsStore brandsStore) : base(brandsStore) { }

}