

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


    }
}
