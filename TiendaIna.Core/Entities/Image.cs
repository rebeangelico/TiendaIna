using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Entities.ClassBase;

namespace TiendaIna.Core.Entities;
[Table("Images")]
public class Image : ImageBase<int, Image>, IEntity<int>  {

    public int Id { get; set; }

}
