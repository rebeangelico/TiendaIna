using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductViewModel : PageModel
    {
        #region static methdos
        public static string PageName => nameof(ProductViewModel).Replace("ViewModel", "");
        #endregion

        #region fields
        private readonly IProductsService _productsService;
        #endregion

        #region properties
        public ProductModel? Product { get; set; }
        #endregion

        #region constructors
        public ProductViewModel(IProductsService productsService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }
        #endregion

        #region public methods
        public async Task<IActionResult> OnGetAsync(int id) {
            Product = await _productsService.GetProduct(id);
            if (Product == null) {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
