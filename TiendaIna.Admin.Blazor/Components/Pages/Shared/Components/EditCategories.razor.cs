using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditCategories : ComponentBase {

        #region fields
        private readonly IProductsService _productsService;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Parameters
        [Parameter] public ProductModel Product { get; set; } = null!;

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public IList<int> SelectedCategories { get; set; } = new List<int>();

        #endregion

        public EditCategories(IProductsService productsService, NavigationManager navigationManager) {
            this._productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            this._navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }


        #region overriden methods
        protected override async Task OnInitializedAsync() {
            Categories = Product.Categories;
        }
        #endregion

        private async Task SaveChanges() {
            if (Product is null) return;
            await _productsService.UpdateProduct(Product);
            _navigationManager.NavigateTo("/products");
        }
    }
}