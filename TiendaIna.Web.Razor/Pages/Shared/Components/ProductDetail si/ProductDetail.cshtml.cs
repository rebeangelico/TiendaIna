using Microsoft.AspNetCore.Mvc.RazorPages;
using TiendaIna.Core.Model;



namespace TiendaIna.Web.Razor.Pages
{
    public class ProductDetailViewModel : PageModel
    {
        public ProductModel Product { get; set; }
        public bool ShowCategories { get; set; } = true;
        public bool ShowRelatedProducts { get; set; } = false;
        public List<ProductModel> RelatedProducts { get; set; } = new List<ProductModel>();
        public bool IsInWishlist { get; set; } = false;
        public bool IsInStock { get; set; } = true;
        public int AvailableQuantity { get; set; } = 0;

        // Propiedades para navegación
        public string? ReturnUrl { get; set; }
        public string? CategoryFilter { get; set; }
        public string? BrandFilter { get; set; }

        // Constructor
        public ProductDetailViewModel(ProductModel product) {
            Product = product;
        }


        // Métodos auxiliares
        public string GetFormattedPrice() {
            return Product.Price?.ToString("C") ?? "$0";
        }

        public string GetProductUrl() {
            return $"/Product/{Product.Id}";
        }

        public string GetBrandUrl() {
            return $"/Marca/{Product.Brand?.Id}";
        }

        public List<string> GetCategoryNames() {
            return Product.Categories?.Select(c => c.Name).ToList() ?? new List<string>();
        }

        public bool HasImage() {
            return !string.IsNullOrEmpty(Product.Imagen);
        }

        public bool HasDescription() {
            return !string.IsNullOrEmpty(Product.Description);
        }

        public bool HasCategories() {
            return Product.Categories != null && Product.Categories.Any();
        }
    }
}