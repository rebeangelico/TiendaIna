using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaIna.Core.Model;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Product {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int idBrand { get; set; }
        public virtual Brand Brand { get; set; }
        public string? DescriptionMin { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public List<int> IdsCategories { get; set; }
        public string? Image { get; set; }
        public ICollection<string> Images { get; set; } = new Collection<string>();

        public string? Gender { get; set; }
        public bool? IsOutstanding { get; set; }


        public Product(ProductModel product) {
            Id = product.Id;
            Name = product.Name;
            Brand = new Brand(product.Brand);
            Price = product.Price;
            DescriptionMin = product.DescriptionMin;
            Description = product.Description;
            Categories = Category.FromCollection(product.Categories);
            IdsCategories = Categories?.Select(c => c.Id).ToList() ?? new List<int>();
            Image = product.Image;
            Images = product.Images;
            Gender = product.Gender;
            IsOutstanding = product.IsOutstanding;

        }
        public Product() {

        }

    }
}