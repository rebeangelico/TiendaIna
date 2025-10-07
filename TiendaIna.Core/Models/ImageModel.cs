using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ImageModel {
    public int Id { get; set; }
    public string? Url { get; set; }
    public string? SmallUrl { get; set; }

    public static ImageModel FromEntity(Image image) => image.Adapt<ImageModel>();

}
