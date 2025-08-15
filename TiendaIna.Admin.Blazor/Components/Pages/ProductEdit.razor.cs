using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ProductEdit : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    #endregion

    #region properties
    [Parameter] public int productId { get; set; }
    public ProductModel? Product { get; set; }
    #endregion

    #region constructors
    public ProductEdit(IProductsService productsService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Product = await ProductsService.GetProduct(productId);
    }
    #endregion
}
