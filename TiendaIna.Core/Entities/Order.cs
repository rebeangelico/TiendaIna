using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Order")]
public class Order : IEntity<int> {
    public int Id { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public int? ClientId { get; set; }
    public int? Amount { get; set; }
    public OrderStatus Status { get; set; }
    //public ICollection<Payment>? Payments { get; set; }
   //public ICollection<ProductInfo>? Products { get; set; }
    public static Order FromModel(OrderModel model) => model.Adapt<Order>();
}
