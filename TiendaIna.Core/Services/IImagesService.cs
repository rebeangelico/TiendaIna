using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface IImagesService {
        Task<List<ImageModel>> GetAll();
        Task<ImageModel> Get(int Id);
        Task<int> Add(ImageModel entity);
        Task Update(ImageModel entity);
        Task Delete(int Id);
    }
}
