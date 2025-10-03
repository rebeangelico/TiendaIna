using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models {
    public class ProductModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public int idBrand { get; set; }
        public virtual BrandModel Brand { get; set; }
        public string? DescriptionMin { get; set; }
        public string? Description { get; set; }
        public IEnumerable<int>? IdsCategories { get; set; }
        public virtual ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public int? Image { get; set; }


        //para no perder la relacion momentaneamente
        public List<int> Images { get; set; }
        public string? Gender { get; set; }
        public bool? IsOutstanding { get; set; }

        public ProductModel() { }

        public ProductModel(Product product) {
            Id = product.Id;
            Name = product.Name;
            Brand = new BrandModel(product.Brand);
            Price = product.Price;
            Stock = product.Stock;
            DescriptionMin = product.DescriptionMin;
            Description = product.Description;
            Categories = CategoryModel.FromCollection(product.Categories);
            IdsCategories = Categories?.Select(c => c.Id).ToList() ?? new List<int>();
            Image = product.Image;
            Images = product.Images;
            Gender = product.Gender;
            IsOutstanding = product.IsOutstanding;
        }
    }

   
}
