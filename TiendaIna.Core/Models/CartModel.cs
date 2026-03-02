using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class CartModel {
    public int? Id { get; set; }
    public ICollection<ProductInfoModel>? Products { get; set; } = [];
    public int QuantityProducts { get; set; }
    public decimal TotalPrice { get; set; }
}
