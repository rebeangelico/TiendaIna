using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Order")]
public class Order : IEntity<int> {
    public int Id { get; set; }
    public int? ClientId { get; set; }
    public ICollection<ProductInfo>? Products { get; set; }
    public int? PaymentId { get; set; }
    public int? Amount { get; set; }
    public OrderStatus Status { get; set; }

    public static Product FromModel(ProductModel model) => model.Adapt<Product>();
}
