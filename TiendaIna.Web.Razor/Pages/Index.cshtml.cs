using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;
using TiendaIna.Web.Razor.Data;

namespace TiendaIna.Web.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsService _productsService;

        public IndexModel(ILogger<IndexModel> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }
        public void OnGet()
        {

        }
    }
}
