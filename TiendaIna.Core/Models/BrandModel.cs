using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models {
    public class BrandModel {
        public int Id { get; set; }
        public string Name { get; set; }

        public BrandModel(Brand brand) {
            Id = brand.Id;
            Name = brand.Name;
        }

    }

}
