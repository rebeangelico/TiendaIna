using Microsoft.AspNetCore.Mvc;
using TiendaIna.Core.Entities;
using TiendaIna.Web.Razor.Pages;

namespace TiendaIna.Web.Razor.ViewComponents;
public class ProductBoxViewComponent : ViewComponent {
    public IViewComponentResult Invoke(Product product) {
        var model = new ProductBoxModel(product);
        return View("ProductBox", model);
    }
}
