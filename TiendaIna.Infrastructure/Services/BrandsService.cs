using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class BrandsService : IBrandsService {
    private readonly IBrandsRepo _brandsRepo;
    private readonly IImagesRepo _imagesRepo;

    public BrandsService(IBrandsRepo brandsRepo, IImagesRepo imagesRepo) {
        this._brandsRepo = brandsRepo ?? throw new ArgumentNullException(nameof(brandsRepo));
        this._imagesRepo = imagesRepo ?? throw new ArgumentNullException(nameof(imagesRepo));
    }

    public async Task<List<BrandModel>> GetAll() {
        var brands = await _brandsRepo.GetAsync();
        var models = brands.Select(b => BrandModel.FromEntity(b)).ToList();
        return models;
    }
    public async Task<BrandModel> Get(int id) {
        var Entity = await _brandsRepo.GetAsync(id);
        var model = BrandModel.FromEntity(Entity);
        return model;
    }

    public Task<int> Add(BrandModel brand) {
        var Entity = Brand.FromModel(brand);
        return _brandsRepo.CreateAsync(Entity);
    }

    public Task Update(BrandModel brand) {
        var Entity = Brand.FromModel(brand);
        return _brandsRepo.UpdateAsync(Entity);
    }

    public async Task Delete(int Id) {
        await _brandsRepo.DeleteAsync(Id);
    }

    public async Task<ImageModel?> GetImage(int id) {
        var brandImage = await _imagesRepo.GetByBrandAsync(id);
        if (brandImage is null) return null;
        return new ImageModel() {
            Id = brandImage.Id,
            Url = !string.IsNullOrWhiteSpace(brandImage.CdnUrl) ? brandImage.CdnUrl : $"images/{brandImage.Id}",
            SmallUrl = !string.IsNullOrWhiteSpace(brandImage.SmallCdnUrl) ? brandImage.SmallCdnUrl : $"images/{brandImage.Id}?size=s",
        };
    }
}

