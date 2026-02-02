using Microsoft.Extensions.Options;
using RepoDb;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class PaymentsDbRepo : CrudDbRepoBase<Payment, int>, IPaymentsRepo {
    public PaymentsDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

    public async Task<IEnumerable<Payment>> GetByOrder(int orderId)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QueryAsync<Payment>(
                p => p.OrderId == orderId
            );
        }

    }
}

