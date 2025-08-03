using System.Collections.Immutable;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Model {
    public class ProductModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int idBrand { get; set; }
        public virtual BrandModel Brand { get; set; }
        public string? DescriptionMin { get; set; }
        public string? Description { get; set; }
        public List<int>? IdsCategories { get; set; }
        public virtual ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public string? Imagen { get; set; }
        public string? Gender { get; set; }
        public bool? IsOutstanding { get; set; }

        public ProductModel(Product product) {
            Id = product.Id;
            Name = product.Name;
            Brand = new BrandModel(product.Brand);
            Price = product.Price;
            DescriptionMin = product.DescriptionMin;
            Description = product.Description;
            Categories = CategoryModel.FromCollection(product.Categories);
            IdsCategories = Categories?.Select(c => c.Id).ToList() ?? new List<int>();
            Imagen = product.Imagen;
            Gender = product.Gender;
            IsOutstanding = product.IsOutstanding;
        }
    }

   
}
