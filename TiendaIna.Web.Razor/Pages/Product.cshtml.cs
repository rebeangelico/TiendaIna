using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;



namespace TiendaIna.Web.Razor.Pages
{
    public class ProductViewModel : PageModel
    {
        #region static methdos
        public static string PageName => nameof(ProductViewModel).Replace("ViewModel", "");
        #endregion

        #region fields
        private readonly IProductsService _productsService;
        private readonly ILogger<IndexViewModel> _logger;
        #endregion

        #region properties
        public List<ProductModel> Products { get; set; }
        public ProductModel? Product { get; set; }
        #endregion

        #region constructors
        public ProductViewModel(IProductsService productsService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }
        #endregion

        #region public methods
        public async Task<IActionResult> OnGetAsync(int? id = null) {
            if (id.HasValue) {
                // Cargar producto específico
                Product = await _productsService.GetProduct(id.Value);
                if (Product == null) {
                    return NotFound();
                }
            } else {
                // Cargar lista de productos
                Products = await _productsService.GetProducts();
            }

            return Page();
        }
        #endregion
    }
}
