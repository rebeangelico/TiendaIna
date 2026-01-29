using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class CartModel {
    public int? Id { get; set; }
    public IEnumerable<ProductInfoModel>? Products { get; set; }
    public int QuantityProducts { get; set; }
    public int TotalPrice { get; set; }
}
