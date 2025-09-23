using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IBrandsService {
        Task<List<BrandModel>> GetAll();
        Task<BrandModel> Get(int Id);
        Task<int> Add(BrandModel entity);
        Task Update(BrandModel entity);
        Task Delete(int Id);
    }
}
