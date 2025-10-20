using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ProductImageOutputModel {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? Url { get; set; }
    public string? SmallUrl { get; set; }
    public int OrderIndex { get; set; }

}
