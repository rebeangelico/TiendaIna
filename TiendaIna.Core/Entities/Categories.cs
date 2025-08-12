

using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Category {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Categorias padre
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        // Colección de categorías hijas
        public virtual ICollection<Category>? ChildCategories { get; set; }

        //coleccion productos por categoria
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public Category(CategoryModel model) {
            Id = model.Id;
            Name = model.Name;
        }
        public Category() {
            
        }
        public static ICollection<Category> FromCollection(ICollection<CategoryModel>? models) {
            return models?.Select(m => new Category(m)).ToList() ?? new List<Category>();
        }

    }
}
