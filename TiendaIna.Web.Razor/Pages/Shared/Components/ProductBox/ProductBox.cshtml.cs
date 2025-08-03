using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductBoxViewModel : PageModel
    {
        public ProductModel Product { get; }
        public bool ShowCategories { get; }

        public ProductBoxViewModel(ProductModel product, bool showCategories) {
            Product = product;
            ShowCategories = showCategories;
        }

    }
}
