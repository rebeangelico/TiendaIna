using TiendaIna.Core.Models;

namespace TiendaIna.Core.Services {
    public interface ICartsService {
        Task<int> AddItem(ProductInfoModel product);
        Task<CartModel> Create(); 
        Task DeleteItem(ProductInfoModel product);
        Task<CartModel> Get();
        Task<CartModel> Update();

        event Action? OnChange;
    }
}
