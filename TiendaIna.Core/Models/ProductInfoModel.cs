
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ProductInfoModel {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int IdProduct { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; } = 0;
    public decimal Price { get; set; }
    public static ProductInfoModel FromEntity(ProductInfo productInfo) => productInfo.Adapt<ProductInfoModel>();
}
