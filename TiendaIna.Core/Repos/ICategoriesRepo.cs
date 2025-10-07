using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Repos {
    public interface ICategoriesRepo : ICrudRepo<Category, int> {
        Task<IEnumerable<Category>> GetByProductAsync(int productId);
    }
}
