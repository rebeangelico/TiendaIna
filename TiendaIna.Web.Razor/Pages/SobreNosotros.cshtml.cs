using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TiendaIna.Web.Razor.Pages
{
    public class SobreNosotrosViewModel : PageModel
    {
        private readonly ILogger<SobreNosotrosViewModel> _logger;

        public SobreNosotrosViewModel(ILogger<SobreNosotrosViewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
