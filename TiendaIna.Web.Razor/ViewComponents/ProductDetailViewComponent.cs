using Microsoft.AspNetCore.Mvc;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Web.Razor.Pages;

namespace TiendaIna.Web.Razor.ViewComponents;
public class ProductDetailViewComponent : ViewComponent {
    public IViewComponentResult Invoke(ProductModel product) {
        var model = new ProductDetailViewModel(product);
        return View("ProductDetail", model);
    }
}
