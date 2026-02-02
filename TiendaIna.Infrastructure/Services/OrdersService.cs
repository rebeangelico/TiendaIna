using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Repos;

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
        throw new NotImplementedException();
    }

    public Task Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderModel> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderModel entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatus(OrderModel entity, OrderStatus status)
    {
        throw new NotImplementedException();
    }
}

