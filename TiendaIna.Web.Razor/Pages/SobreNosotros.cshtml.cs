using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TiendaIna.Web.Razor.Pages
{
    public class SobreNosotrosModel : PageModel
    {
        private readonly ILogger<SobreNosotrosModel> _logger;

        public SobreNosotrosModel(ILogger<SobreNosotrosModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
