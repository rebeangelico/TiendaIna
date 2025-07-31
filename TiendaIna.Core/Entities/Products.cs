using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaIna.Core.Entities {
    public class Product {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int idBrand { get; set; }
        public virtual Brand Brand { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public string? Imagen { get; set; }
        public string? Gender { get; set; }
        public bool? IsOutstanding { get; set; }
    }
}
