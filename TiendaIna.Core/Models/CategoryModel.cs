using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models {
    public class CategoryModel {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }

        public static CategoryModel FromEntity(Category category) => category.Adapt<CategoryModel>();

        public CategoryModel Clone() => (CategoryModel)this.MemberwiseClone();
    }

}
