using Microsoft.Extensions.Options;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;
using TiendaIna.Core.Repos;

namespace TiendaIna.Infrastructure.Repos;

public class OrdersDbRepo : CrudDbRepoBase<Order, int>, IOrdersRepo
{
    public OrdersDbRepo(IOptions<AppSettings> appSettings) : base(appSettings) { }

}

