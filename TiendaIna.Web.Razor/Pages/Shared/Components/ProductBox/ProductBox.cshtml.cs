using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductBoxModel : PageModel
    {
        public Product Product { get; }

        public ProductBoxModel(Product product) {
            Product = product;
        }

    }
}
