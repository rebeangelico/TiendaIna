using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface ICategoriesRepo {
        Task<List<Category>> GetAsync();
        Task<Category> Get(int id);
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(int id);

    }
}
