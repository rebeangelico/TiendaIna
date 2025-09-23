using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class CategoriesService : ICategoriesService {
    private readonly ICategoriesRepo _categoriesRepo;
    public CategoriesService(ICategoriesRepo categoriesRepo) {
        this._categoriesRepo = categoriesRepo ?? throw new ArgumentNullException(nameof(categoriesRepo));
    }

    public async Task<List<CategoryModel>> GetAll() {
        var categories = await _categoriesRepo.GetAllAsync();
        var models = categories.Select(c => new CategoryModel(c)).ToList();
        return models;
    }
    public async Task<CategoryModel> Get(int categoryId) {
        var category = await _categoriesRepo.GetAsync(categoryId);
        var model = new CategoryModel(category);
        return model;
    }

    public Task<int> Add(CategoryModel category) {
        var Entity = new Category(category);
        return _categoriesRepo.CreateAsync(Entity);
    }

    public Task Update(CategoryModel category) {
        var Entity = new Category(category);
        return _categoriesRepo.UpdateAsync(Entity);
    }

    public Task Delete(int Id) => _categoriesRepo.DeleteAsync(Id);
}

