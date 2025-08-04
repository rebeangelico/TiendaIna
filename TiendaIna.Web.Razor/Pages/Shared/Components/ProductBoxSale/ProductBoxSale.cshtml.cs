using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductBoxSaleViewModel : PageModel
    {
        public ProductModel Product { get; }
        public List<CategoryModel> Categories { get; }
        public double Descuento { get; set; } = 0.20;
        public double PrecioConDescuento { get; set; }
        public string PrecioFormateado { get; set; }



        public ProductBoxSaleViewModel(ProductModel product) {
            Product = product;
            Categories = Product.Categories?.ToList() ?? new List<CategoryModel>();
            Descuento = 0.20;
            PrecioConDescuento = 0;
            PrecioFormateado = PrecioConDescuento.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            if (product.Price.HasValue) {
                PrecioConDescuento = product.Price.Value - (product.Price.Value * Descuento);
            }
        }

    }
}
