using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;
using TiendaIna.Infrastructure.DataStore;

namespace TiendaIna.Infrastructure.Repos;

public class BrandsInMemoryRepo : InMemoryRepoBase<Brand, int>, IBrandsRepo {
    public BrandsInMemoryRepo(IInMemoryBrandsStore brandsStore) : base(brandsStore) { }

    public override Task<int> CreateAsync(Brand entity) {
        entity.Id = Random.Shared.Next(1, 100000);
        return base.CreateAsync(entity);
    }
}