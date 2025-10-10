using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class BrandModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ImageId { get; set; }

    public static BrandModel FromEntity(Brand brand) => brand.Adapt<BrandModel>();
}
