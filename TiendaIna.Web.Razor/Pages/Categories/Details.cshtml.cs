using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaIna.Core.Entities;

namespace TiendaIna.Web.Razor.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly TiendaIna.Web.Razor.Data.TiendaInaWebRazorContext _context;

        public DetailsModel(TiendaIna.Web.Razor.Data.TiendaInaWebRazorContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
