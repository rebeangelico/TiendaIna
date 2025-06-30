using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Services {
    public interface ICategoriesService {
        Task<List<Category>> GetCategories();
    }
}
