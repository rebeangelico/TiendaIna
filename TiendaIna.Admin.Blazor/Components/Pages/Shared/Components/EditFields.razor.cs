using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditFields : ComponentBase {

        #region fields
        private readonly IProductsService _productsService;
        private readonly NavigationManager _navigationManager;
        #endregion

        #region Parameters
        [Parameter] public ProductModel Product { get; set; } = null!;

        [Parameter] public bool? ShowName { get; set; }
        [Parameter] public bool? ShowPrice { get; set; }
        [Parameter] public bool? ShowBrand { get; set; }
        [Parameter] public bool? ShowDescriptionMin { get; set; }
        [Parameter] public bool? ShowDescription { get; set; }
        [Parameter] public bool? ShowCategories { get; set; }
        [Parameter] public bool? ShowGender { get; set; }
        [Parameter] public bool? ShowIsOutstanding { get; set; }
        #endregion

        public EditFields(IProductsService productsService, NavigationManager navigationManager) {
            this._productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            this._navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }

        private async Task SaveChanges() {
            if (Product is null) return;
            await _productsService.UpdateProduct(Product);
            _navigationManager.NavigateTo("/products");
        }
    }
}