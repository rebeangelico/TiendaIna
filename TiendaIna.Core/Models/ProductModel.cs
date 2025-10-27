using Mapster;
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ProductModel {
    public int Id { get; set; }
    public int? BrandId { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? DescriptionShort { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public bool IsOutstanding { get; set; }

    public BrandModel? Brand { get; set; }
    public IEnumerable<CategoryModel>? Categories { get; set; }
    public SortedList<int, ProductImageOutputModel>? Images { get; set; }

    public static ProductModel FromEntity(Product product) => product.Adapt<ProductModel>();
}
