
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Brand {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Brand(BrandModel model) {
            Id = model.Id;
            Name = model.Name;
        }
        public Brand() {
            
        }
    }
}
