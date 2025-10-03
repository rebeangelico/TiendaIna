using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Product : IEntity<int> {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public int idBrand { get; set; }

        [Ignore]
        public virtual Brand Brand { get; set; }
        public string? DescriptionMin { get; set; }
        public string? Description { get; set; }

        [Ignore]
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        [Ignore]
        public IEnumerable<int> IdsCategories { get; set; }
        public int? Image { get; set; }

        [Ignore]



        public List<int> Images { get; set; } = new List<int>();
        public string? Gender { get; set; }
        public bool? IsOutstanding { get; set; }


        public Product(ProductModel product) {
            Id = product.Id;
            Name = product.Name;
            Brand = new Brand(product.Brand);
            Price = product.Price;
            Stock = product.Stock;
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