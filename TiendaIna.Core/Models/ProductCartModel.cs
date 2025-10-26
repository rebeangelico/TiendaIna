using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ProductCartModel {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}
