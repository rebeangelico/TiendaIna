using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaIna.Core.Entities {
    public class Product {
        public int Id { get; set; }
        public string? name { get; set; }
        public int? precio { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? imagen { get; set; }
    }
}
