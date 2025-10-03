using System.Collections.Generic;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class ImagesService : IImagesService {
    private readonly IImagesRepo _imagesRepo;
    public ImagesService(IImagesRepo imagesRepo) {
        this._imagesRepo = imagesRepo ?? throw new ArgumentNullException(nameof(imagesRepo));
    }

    public Task Delete(int Id) => _imagesRepo.DeleteAsync(Id);

    public async Task<List<ImageModel>> GetAll() {
        var images = await _imagesRepo.GetAllAsync();
        var models = images.Select(i => new ImageModel(i)).ToList();
        return models;
    }

    public async Task<ImageModel> Get(int Id) {
        var image = await _imagesRepo.GetAsync(Id);
        var model = new ImageModel(image);
        return model;
    }

    public Task<int> Add(ImageModel image) {
        var Entity = new Image(image);
        return _imagesRepo.CreateAsync(Entity);
    }

    public Task Update(ImageModel image) {
        var Entity = new Image(image);
        return _imagesRepo.UpdateAsync(Entity);
    }

    public async Task<List<ImageModel>> GetListProduct(List<int> ids) {
        var result = new List<ImageModel>();
        foreach (var id in ids) {
            var image = await _imagesRepo.GetAsync(id);
            if (image != null) {
                result.Add(new ImageModel(image));
            }
        }
        return result;
    }
}

