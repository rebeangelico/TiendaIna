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
        public virtual Brand Brand { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; }
        public string? Imagen { get; set; }
    }
}
