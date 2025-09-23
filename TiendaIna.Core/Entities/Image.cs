
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities {
    public class Image : IEntity<int> {
        public int Id { get; set; } 
        public string Url { get; set; }

        public Image(ImageModel model) {
            Id = model.Id;
            Url = model.Url;
        }
        public Image() {
            
        }
    }
}
