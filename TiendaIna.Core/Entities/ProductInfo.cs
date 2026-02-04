using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("ProductInfo")]
public class ProductInfo : IEntity<int> {
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public int IdOrder{ get; set; }
    public string? Name { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price{ get; set; }


    public static ProductInfo FromModel(ProductInfoModel model) => model.Adapt<ProductInfo>();
}
