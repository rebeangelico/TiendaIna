using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models {
    public class ImageModel {
        public int Id { get; set; }
        public string Url { get; set; }
        public string CdnUrl { get; set; }

        public ImageModel() { }

        public ImageModel(Image brand) {
            Id = brand.Id;
            Url = brand.Url;
            CdnUrl = brand.CdnUrl;
        }

    }

}
