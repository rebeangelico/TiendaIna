using TiendaIna.Core.Entities;
using TiendaIna.Core.Repos;


namespace TiendaIna.Infrastructure.Repos {
    public class CategoriesInMemoryRepo : ICategoriesRepo {

        #region Readonly Categories
        private readonly IInMemoryCategories _categories;
        #endregion


        public CategoriesInMemoryRepo(IInMemoryCategories categories) {
            _categories = categories ?? throw new ArgumentNullException(nameof(categories));
        }
        public void AddCategory(Category category) {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoriesAsync() {
            return Task.FromResult((List<Category>)_categories); ;
        }

        public Task<Category> GetCategory(int categoryId) {
            throw new NotImplementedException();
        }

        public void UpdateCategory(int categoryId) {
            throw new NotImplementedException();
        }
    }
}
