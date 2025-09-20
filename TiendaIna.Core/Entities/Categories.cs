

using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Category : IEntity<int> {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public Category(CategoryModel model) {
            Id = model.Id;
            Name = model.Name;
            ParentCategoryId = model.ParentCategoryId;
        }
        public Category() {
            
        }
        public static ICollection<Category> FromCollection(ICollection<CategoryModel>? models) {
            return models?.Select(m => new Category(m)).ToList() ?? new List<Category>();
        }

    }
}
