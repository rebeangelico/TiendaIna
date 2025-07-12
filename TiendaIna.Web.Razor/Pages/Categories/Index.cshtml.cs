using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaIna.Core.Entities;

namespace TiendaIna.Web.Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly TiendaIna.Web.Razor.Data.TiendaInaWebRazorContext _context;

        public IndexModel(TiendaIna.Web.Razor.Data.TiendaInaWebRazorContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories
                .Include(c => c.ParentCategory).ToListAsync();
        }
    }
}
