using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductBoxSaleViewModel : PageModel
    {
        public ProductModel Product { get; }

        public ProductBoxSaleViewModel(ProductModel product) {
            Product = product;
        }

    }
}
