using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Entities.ClassBase;

namespace TiendaIna.Core.Entities {
    [Table("ProductImages")]
    public class ProductImage : ImageBase<int, ProductImage>, IEntity<int> {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderIndex { get; set; }
    }
}
