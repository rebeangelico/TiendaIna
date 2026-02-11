using TiendaIna.Core;
using TiendaIna.Core.Entities;
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

    public Task UpdateStatus(int id, PaymentStatus status) {
        var entity = _paymentsRepo.GetAsync(id).Result;
         entity.Status = status;
        return _paymentsRepo.UpdateAsync(entity);
    }

    public Task<int> Add(PaymentModel entity) {
        var Entity = Payment.FromModel(entity);
        return _paymentsRepo.CreateAsync(Entity);
    }

    public Task Delete(int Id) {
        return _paymentsRepo.DeleteAsync(Id);
    }

    public async Task<PaymentModel> Get(int id) {
        var payment = await _paymentsRepo.GetAsync(id);
        var model = PaymentModel.FromEntity(payment);
        return model;
    }

    public async Task<List<PaymentModel>> GetAll() {
        var payments = await _paymentsRepo.GetAsync();
        var models = payments.Select(p => PaymentModel.FromEntity(p)).ToList();
        return models;
    }

    public Task Update(PaymentModel payment) {
        var entity = Payment.FromModel(payment);
        return _paymentsRepo.UpdateAsync(entity);
    }

    public async Task<List<PaymentModel>> GetFromOrder(int OrderId) {
        var payments = await _paymentsRepo.GetByOrder(OrderId);
        var models = payments.Select(p => PaymentModel.FromEntity(p)).ToList();
        return models;
    }
}

