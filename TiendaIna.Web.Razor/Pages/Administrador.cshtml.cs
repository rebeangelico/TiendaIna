using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Entities;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Web.Razor.Pages
{
    public class AdministradorModel : PageModel
    {
        private readonly CategoriesService _categoriesService;
        private readonly ProductsService _productsService;
        public AdministradorModel(CategoriesService categoriesService, ProductsService productsService) {
            _categoriesService = categoriesService;
            _productsService = productsService;
        }
        public Category Category { get; set; }
        public Product Product { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost(Category category){ 
            _categoriesService.AddCategory(Category);
            return RedirectToPage("gracias");
        }
    }
}
