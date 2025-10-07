using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    [Table("Categories")]
    public class Category : IEntity<int> {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }

        public static Category FromModel(CategoryModel model) => model.Adapt<Category>();
    }
}
