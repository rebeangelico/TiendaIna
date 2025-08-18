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

        [Parameter] public bool? ShowName { get; set; }
        [Parameter] public bool? ShowPrice { get; set; }
        [Parameter] public bool? ShowBrand { get; set; }
        [Parameter] public bool? ShowDescriptionMin { get; set; }
        [Parameter] public bool? ShowDescription { get; set; }
        [Parameter] public bool? ShowCategories { get; set; }
        [Parameter] public bool? ShowGender { get; set; }
        [Parameter] public bool? ShowIsOutstanding { get; set; }
        #endregion

        /*public EditFields(ProductModel product, bool showName, bool showPrice, bool showBrand, bool showDescriptionMin, bool showDescription, bool showCategories, bool showGender, bool showIsOutstanding) {
            Product = product;
            ShowName = showName;
            ShowPrice = showPrice;
            ShowBrand = showBrand;
            ShowDescriptionMin = showDescriptionMin;
            ShowDescription = showDescription;
            ShowCategories = showCategories;
            ShowGender = showGender;
            ShowIsOutstanding = showIsOutstanding;
        }*/

        private async Task SaveChanges() {
            if (Product is null) return;
            await ProductsService!.UpdateProduct(Product);
            NavigationManager!.NavigateTo("/products");
        }
    }
}