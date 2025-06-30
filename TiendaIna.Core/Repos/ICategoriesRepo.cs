using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface ICategoriesRepo {
        Task<List<Category>> GetCategoriesAsync();

    }
}
