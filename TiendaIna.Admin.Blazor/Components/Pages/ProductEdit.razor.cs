using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ProductEdit : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly NavigationManager _navigationManager;
    #endregion

    #region properties
    [Parameter] public int productId { get; set; }
    public ProductModel? Product { get; set; }
    #endregion

    #region constructors
    public ProductEdit(IProductsService productsService, NavigationManager navigationManager) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Product = await ProductsService.GetProduct(productId);
    }


    #endregion
    void NavegarA(string url) {
        _navigationManager.NavigateTo(url);
    }

}
