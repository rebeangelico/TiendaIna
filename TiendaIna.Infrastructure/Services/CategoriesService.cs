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

    public async Task<List<CategoryModel>> GetCategories() {
        var categories = await _categoriesRepo.GetAllAsync();
        var models = categories.Select(c => new CategoryModel(c)).ToList();
        return models;
    }
    public async Task<CategoryModel> GetCategory(int categoryId) {
        var category = await _categoriesRepo.GetAsync(categoryId);
        var model = new CategoryModel(category);
        return model;
    }

    public Task<int> AddCategory(CategoryModel category) {
        var Entity = new Category(category);
        return _categoriesRepo.CreateAsync(Entity);
    }

    public Task UpdateCategory(CategoryModel category) {
        var Entity = new Category(category);
        return _categoriesRepo.UpdateAsync(Entity);
    }

    public Task DeleteCategory(int Id) => _categoriesRepo.DeleteAsync(Id);
}

