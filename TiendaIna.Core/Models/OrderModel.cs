
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class OrderModel {
    public int Id { get; set; }
    public ClientModel? Client { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public ICollection<ProductInfoModel>? Products { get; set; }
    public int? Amount { get; set; }
    public ICollection<PaymentModel>? Payments { get; set; }
    public OrderStatus Status { get; set; }

    public static OrderModel FromEntity(Order order) => order.Adapt<OrderModel>();
}
