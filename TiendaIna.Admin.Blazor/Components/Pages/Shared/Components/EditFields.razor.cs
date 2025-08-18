using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditFields : ComponentBase {

        #region fields
        [Inject] public IProductsService? ProductsService { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Parameters
        [Parameter] public ProductModel Product { get; set; } = null!;
        public bool? ShowName { get; }
        public bool? ShowPrice { get; }
        public bool? ShowBrand { get; }
        public bool? ShowDescriptionMin { get; }
        public bool? ShowDescription { get; }
        public bool? ShowCategories { get; }
        public bool? ShowGender { get; }
        public bool? ShowIsOutstanding { get; }
        #endregion

        public EditFields(ProductModel product, bool showName, bool showPrice, bool showBrand, bool showDescriptionMin, bool showDescription, bool showCategories, bool showGender, bool showIsOutstanding) {
            Product = product;
            ShowName = showName;
            ShowPrice = showPrice;
            ShowBrand = showBrand;
            ShowDescriptionMin = showDescriptionMin;
            ShowDescription = showDescription;
            ShowCategories = showCategories;
            ShowGender = showGender;
            ShowIsOutstanding = showIsOutstanding;
        }

        private async Task SaveChanges() {
            if (Product is null) return;
            await ProductsService!.UpdateProduct(Product);
            NavigationManager!.NavigateTo("/products");
        }
    }
}