
namespace TiendaIna.Core.Models;

public class ProductInfoModel {
    public int Id { get; set; }
    public int IdPedido { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}
