using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaIna.Core.Entities;
[Table("Images")]
public class Image : IEntity<int> {

    public int Id { get; set; }
    public byte[]? Data { get; set; }
    public string? CdnUrl { get; set; }
    public byte[]? SmallData { get; set; }
    public string? SmallCdnUrl { get; set; }
    public string? MimeType { get; set; }
}

public class OrderedImage : Image {
    public int OrderIndex { get; set; }
}