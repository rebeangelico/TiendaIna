using TiendaIna.Core;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepo _ordersRepo;
    private readonly IClientsRepo _clientsRepo;
    private readonly IPaymentsRepo _paymentsRepo;
    private readonly IProductsInfoRepo _productsInfoRepo;

    public OrdersService(IOrdersRepo ordersRepo, IClientsRepo clientsRepo, IPaymentsRepo paymentsRepo, IProductsInfoRepo productsInfoRepo) {
        this._ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
        this._clientsRepo = clientsRepo ?? throw new ArgumentNullException(nameof(clientsRepo));
        this._paymentsRepo = paymentsRepo ?? throw new ArgumentNullException(nameof(paymentsRepo));
        this._productsInfoRepo = productsInfoRepo ?? throw new ArgumentNullException(nameof(productsInfoRepo));
    }

    public Task<int> Add(OrderModel entity)
    {
        var Entity = Order.FromModel(entity);
        return _ordersRepo.CreateAsync(Entity);
    }

    public Task Delete(int Id) => _ordersRepo.DeleteAsync(Id);

    public async Task<OrderModel> Get(int id) {
        var order = await _ordersRepo.GetAsync(id);
        var payments = await GetPayments(id);
        var model = OrderModel.FromEntity(order);
        model.Payments = payments;
        model.LastPayment = GetLastStatusPayment(payments);
        model.Products = await GetProductsInfo(id);
        model.Client = await GetClient(id);
        return model;
    }

    public async Task<List<OrderModel>> GetAll() {
        var orders = await _ordersRepo.GetAsync();
        var models = new List<OrderModel>();
        foreach (var order in orders) {
            var model = await Get(order.Id);
            models.Add(model);
        }
        return models;
    }

    public Task Update(OrderModel entityModel) {
        var entity = Order.FromModel(entityModel);
        return _ordersRepo.UpdateAsync(entity);
    }

    public Task UpdateStatus(int id, OrderStatus status) {
        var entity = _ordersRepo.GetAsync(id).Result;
        entity.Status = status;
        return _ordersRepo.UpdateAsync(entity);
    }

    #region Helpers
    private async Task<ICollection<ProductInfoModel>> GetProductsInfo(int orderId) {
        var productInfos = await _productsInfoRepo.GetByOrder(orderId);
        var models = productInfos
                            .Select(p => ProductInfoModel.FromEntity(p))
                            .ToList();
        return models;
    }

    private async Task<ICollection<PaymentModel>> GetPayments(int orderId) {
        var payments = await _paymentsRepo.GetByOrder(orderId);
        var models = payments
                            .Select(p => PaymentModel.FromEntity(p))
                            .ToList();
        return models;
    }

    private async Task<ClientModel> GetClient(int id) { 
        var client = await _clientsRepo.GetAsync(id);
        var model = ClientModel.FromEntity(client);
        return model;
    }
    private PaymentModel GetLastStatusPayment(ICollection<PaymentModel> payments) {
        var ultimoPago = payments?
                                .OrderByDescending(p => p.DateTime)
                                .FirstOrDefault();
        return ultimoPago!;
    }
    #endregion

    #region Helper
    public decimal CalculadorAmount(ICollection<ProductInfoModel> Products)
    {
        decimal amount = 0;
        decimal price = 0;
        foreach (var product in Products)
        {
            price = product.Price * product.Quantity;
            amount = amount + price;
        }
        return amount;
    }
    #endregion

}





