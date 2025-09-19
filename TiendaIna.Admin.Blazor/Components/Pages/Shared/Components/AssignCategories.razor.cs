using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class AssignCategories : ComponentBase {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;

        public AssignCategories(ICategoriesService categoriesService, IProductsService productsService) {
            _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        [Parameter] public int productId { get; set; }

        public List<CategoryModel> categories = new();

        public IEnumerable<int> selectedCategoriesIds;

        protected override async Task OnInitializedAsync() {
            categories = await _categoriesService.GetCategories(); 
            selectedCategoriesIds = await _productsService.GetCategoriesIds(productId); 
        }


        async Task OnCategoriesChanged(IEnumerable<int> value) {
            selectedCategoriesIds = value;

            var product = await ProductsService.GetProduct(productId);
            product.IdsCategories = selectedCategoriesIds;

            await ProductsService.UpdateProduct(product);
        }

        async Task GuardarCategorias() {
            var product = await _productsService.GetProduct(productId);
            product.IdsCategories = selectedCategoriesIds;
            await _productsService.UpdateProduct(product);
        }


    }
}