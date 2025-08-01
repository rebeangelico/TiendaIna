using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Web.Razor.Pages
{
    public class ProductModel : PageModel
    {
        public static string PageName => nameof(ProductModel).Replace("Model", "");


        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsService _productsService;

        public ProductModel(ILogger<IndexModel> logger, IProductsService productsService) {
            _logger = logger;
            _productsService = productsService;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string abc) {
            Product = await _productsService.GetProduct(id);
            if (Product == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
