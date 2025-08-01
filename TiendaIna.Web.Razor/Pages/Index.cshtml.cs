using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;
using TiendaIna.Web.Razor.Data;

namespace TiendaIna.Web.Razor.Pages
{
    public class IndexViewModel : PageModel
    {
        private readonly ILogger<IndexViewModel> _logger;
        private readonly IProductsService _productsService;

        public IEnumerable<ProductViewModel> MyProperty { get; set; }

        public IndexViewModel(ILogger<IndexViewModel> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }
        public void OnGet()
        {

        }
    }
}
