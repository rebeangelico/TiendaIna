using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductBoxViewModel : PageModel
    {
        public Product Product { get; }
        public bool ShowCategories { get; }

        public ProductBoxViewModel(Product product, bool showCategories) {
            Product = product;
            ShowCategories = showCategories;
        }

    }
}
