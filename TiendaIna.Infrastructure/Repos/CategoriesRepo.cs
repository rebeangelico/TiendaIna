using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos {
    public class CategoriesRepo : ICategoriesRepo {
        public Task<List<Category>> GetCategoriesAsync() {
            throw new NotImplementedException();
        }
        public Task<Category> GetCategory(int categoryId) {
            throw new NotImplementedException();
        }
        public void AddCategory(Category category) {
            throw new NotImplementedException();
        }
        public void DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }
        public void UpdateCategory(int categoryId) {
            throw new NotImplementedException();
        }
    }
}
