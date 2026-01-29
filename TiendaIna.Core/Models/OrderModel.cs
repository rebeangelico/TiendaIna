
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class OrderModel {
    public int Id { get; set; }
    public int? ClientId { get; set; }
    public ICollection<ProductInfo>? Products { get; set; }
    public int? PaymentId { get; set; }
    public int? Amount { get; set; }
    public OrderStatus Status { get; set; }
}
