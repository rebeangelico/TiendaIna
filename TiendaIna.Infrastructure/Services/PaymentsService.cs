using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;
using TiendaIna.Core.Services;

namespace TiendaIna.Infrastructure.Services;

public class PaymentsService : IPaymentsService
{
    private readonly IPaymentsRepo _paymentsRepo;

    public PaymentsService(IPaymentsRepo paymentsRepo) {
        this._paymentsRepo = paymentsRepo ?? throw new ArgumentNullException(nameof(paymentsRepo));
    }

    public Task<int> Add(PaymentModel entity)
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

    public Task<List<PaymentModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(PaymentModel entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatus(PaymentModel entity, PaymentStatus status)
    {
        throw new NotImplementedException();
    }
}

