using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaIna.Core.Entities {
    [Table("ProductImages")]
    public class ProductImage : IEntity<int> {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public int OrderIndex { get; set; }
        public bool IsCover { get; set; }
    }
}
