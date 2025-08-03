using Microsoft.AspNetCore.Mvc;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Web.Razor.Pages;

namespace TiendaIna.Web.Razor.ViewComponents;
public class ProductBoxViewComponent : ViewComponent {
    public IViewComponentResult Invoke(ProductModel product, bool showCategories) {
        var model = new ProductBoxViewModel(product, showCategories);
        return View("ProductBox", model);
    }
}
