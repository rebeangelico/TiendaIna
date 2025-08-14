using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ProductsList : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    #endregion

    #region properties
    public List<ProductModel>? Products { get; set; }
    #endregion

    #region constructors
    public ProductsList(IProductsService productsService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Products = await _productsService.GetProducts();
    }
    #endregion
}
