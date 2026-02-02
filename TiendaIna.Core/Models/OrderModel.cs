
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class OrderModel {
    public int Id { get; set; }
    public int? ClientId { get; set; }
    public DateTime DateTime { get; set; }
    public ICollection<ProductInfo>? Products { get; set; }
    public int? Amount { get; set; }
    public ICollection<Payment>? Payments { get; set; }
    public OrderStatus Status { get; set; }
}
