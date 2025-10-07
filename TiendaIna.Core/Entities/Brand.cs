using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Brands")]
public class Brand : IEntity<int> {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ImageId { get; set; }

    public static Brand FromModel(BrandModel model) => model.Adapt<Brand>();
}