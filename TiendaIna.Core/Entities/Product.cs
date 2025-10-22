using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Products")]
public class Product : IEntity<int> {
    public int Id { get; set; }
    public int? BrandId { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? DescriptionShort { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public bool IsVisible { get; set; }

    public static Product FromModel(ProductModel model) => model.Adapt<Product>();
}
