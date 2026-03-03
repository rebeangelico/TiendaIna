using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class CartsService : ICartsService {

    #region Prop

    private readonly CartModel _cart;

    public event Action? OnChange;

    #endregion

    #region Ctor

    public CartsService() {
        _cart = new CartModel() { };
    }

    #endregion

    #region Methods
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
        // Logs
       // var suscriptores = OnChange?.GetInvocationList().Length ?? 0;
       // Console.WriteLine($"🔔 OnChange invocado - suscriptores: {suscriptores}");

        OnChange?.Invoke();
        return Task.FromResult(_cart.QuantityProducts);
    }

    public Task<CartModel> Create() => Task.FromResult(new CartModel());

    public Task DeleteItem(ProductInfoModel product)
    {
        _cart.Products!.Remove(product);
        _cart.QuantityProducts = _cart.Products.Sum(p => p.Quantity);
        _cart.TotalPrice = _cart.Products.Sum(p => p.Price * p.Quantity);

        OnChange?.Invoke();
        return Task.CompletedTask;
    }

    public Task<CartModel> Get() => Task.FromResult(_cart);

    public Task UpdateItemQuantity(ProductInfoModel product, int newQuantity)
    {
        if (_cart.Products is List<ProductInfoModel> products)
        {
            var existing = products.FirstOrDefault(p => p.IdProduct == product.IdProduct);
            if (existing != null)
                existing.Quantity = newQuantity;

            _cart.QuantityProducts = products.Sum(p => p.Quantity);
            _cart.TotalPrice = products.Sum(p => p.Price * p.Quantity);
        }
        OnChange?.Invoke();
        return Task.CompletedTask;
    }

    #endregion

}