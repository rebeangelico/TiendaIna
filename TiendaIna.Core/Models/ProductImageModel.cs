using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ProductImageModel {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public byte[]? Data { get; set; }
    public string? CdnUrl { get; set; }
    public byte[]? SmallData { get; set; }
    public string? SmallCdUrl { get; set; }
    public string? MimeType { get; set; }
    public int OrderIndex { get; set; }

    public static ProductImageModel FromEntity(ProductImage productImage) => productImage.Adapt<ProductImageModel>();
}
