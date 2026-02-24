using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class CartsService : ICartsService
{
    private readonly CartModel _cart;

    public CartsService()
    {
        _cart = new CartModel() { Id = 5, TotalPrice = 10000, Products = new List<ProductInfoModel>() };
    }

    public event Action? OnChange;

    public Task<int> AddItem(ProductInfoModel product)
    {
        if (_cart.Products is List<ProductInfoModel> products)
        {
            var existing = products.FirstOrDefault(p => p.IdProduct == product.IdProduct);
            if (existing != null)
            {
                existing.Quantity += product.Quantity;
            }
            else
            {
                products.Add(product);
            }

            _cart.QuantityProducts = products.Sum(p => p.Quantity);
            _cart.TotalPrice = products.Sum(p => p.Price * p.Quantity);
        }

        OnChange?.Invoke(); // ✅ Notificar a los componentes
        return Task.FromResult(_cart.QuantityProducts);
    }

    public Task<CartModel> Create() => Task.FromResult(new CartModel());

    public Task DeleteItem(ProductInfoModel product)
    {
        _cart.Products.Remove(product);
        _cart.QuantityProducts = _cart.Products.Sum(p => p.Quantity);
        _cart.TotalPrice = _cart.Products.Sum(p => p.Price * p.Quantity);

        OnChange?.Invoke(); // ✅ Notificar
        return Task.CompletedTask;
    }

    public Task<CartModel> Get() => Task.FromResult(_cart);

    public Task<CartModel> Update() => throw new NotImplementedException();
}