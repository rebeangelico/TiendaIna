using Microsoft.AspNetCore.Mvc;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Web.Razor.Pages;

namespace TiendaIna.Web.Razor.ViewComponents;
public class ProductBoxSaleViewComponent : ViewComponent {
    public IViewComponentResult Invoke(ProductModel product) {
        var model = new ProductBoxSaleViewModel(product);
        return View("ProductBoxSale", model);
    }
}
