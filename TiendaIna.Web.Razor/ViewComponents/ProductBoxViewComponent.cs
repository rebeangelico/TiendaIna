using Microsoft.AspNetCore.Mvc;
using TiendaIna.Core.Entities;
using TiendaIna.Web.Razor.Pages;

namespace TiendaIna.Web.Razor.ViewComponents;
public class ProductBoxViewComponent : ViewComponent {
    public IViewComponentResult Invoke(Product product, bool showCategories) {
        var model = new ProductBoxModel(product, showCategories);
        return View("ProductBox", model);
    }
}
