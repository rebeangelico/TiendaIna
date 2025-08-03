using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models {
    public class CategoryModel {
        public int Id { get; set; }
        public string? Name { get; set; }

        public CategoryModel(Category category) {
            Id = category.Id;
            Name = category.Name;
        }
        public CategoryModel(ICollection<Category> categories) {
            throw new InvalidOperationException("Use CategoryModel.FromCollection instead.");
        }

        public static ICollection<CategoryModel> FromCollection(ICollection<Category> categories) {
            return categories?.Select(c => new CategoryModel(c)).ToList() ?? new List<CategoryModel>();
        }
    }

}
