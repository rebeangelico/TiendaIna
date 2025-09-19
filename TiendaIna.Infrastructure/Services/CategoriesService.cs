using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services {
    public class CategoriesService : ICategoriesService {
        private readonly ICategoriesRepo _categoriesRepo;
        public CategoriesService(ICategoriesRepo categoriesRepo) {
            this._categoriesRepo = categoriesRepo ?? throw new ArgumentNullException(nameof(categoriesRepo));
        }

        public async Task<List<CategoryModel>> GetCategories() {
            var categories = await _categoriesRepo.GetAsync();
            var models = categories.Select(c => new CategoryModel(c)).ToList();
            return models;
        }
        public async Task<CategoryModel> GetCategory(int categoryId) {
            throw new NotImplementedException();
        }

        Task ICategoriesService.AddCategory(CategoryModel category) {
            throw new NotImplementedException();
        }

        Task ICategoriesService.UpdateCategory(CategoryModel category) {
            throw new NotImplementedException();
        }

        Task ICategoriesService.DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }
    }
}
