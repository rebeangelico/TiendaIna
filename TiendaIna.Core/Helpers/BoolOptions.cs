using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaIna.Core {
    public class BoolOptions {
        public string Label { get; set; } = "";
        public bool Value { get; set; }
    }
    public static class UIOptions {

        public static readonly List<BoolOptions> SiNo = new()
        {
            new BoolOptions { Label = "Sí", Value = true },
            new BoolOptions { Label = "No", Value = false }
        };
    }

}
