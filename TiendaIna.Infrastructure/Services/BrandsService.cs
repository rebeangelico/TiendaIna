using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class BrandsService : IBrandsService {
    private readonly IBrandsRepo _brandsRepo;
    public BrandsService(IBrandsRepo brandsRepo) {
        this._brandsRepo = brandsRepo ?? throw new ArgumentNullException(nameof(brandsRepo));
    }

    public async Task<List<BrandModel>> GetAll() {
        var brands = await _brandsRepo.GetAllAsync();
        var models = brands.Select(b => new BrandModel(b)).ToList();
        return models;
    }
    public async Task<BrandModel> Get(int id) {
        var Entity = await _brandsRepo.GetAsync(id);
        var model = new BrandModel(Entity);
        return model;
    }

    public Task<int> Add(BrandModel brand) {
        var Entity = new Brand(brand);
        return _brandsRepo.CreateAsync(Entity);
    }

    public Task Update(BrandModel brand) {
        var Entity = new Brand(brand);
        return _brandsRepo.UpdateAsync(Entity);
    }

    public async Task Delete(int Id) {
        await _brandsRepo.DeleteAsync(Id);
    }
}

