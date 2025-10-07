using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components;

public partial class AssignCategories : ComponentBase {
    #region fields
    private readonly ICategoriesService _categoriesService;
    private readonly IProductsService _productsService;
    #endregion

    #region properties
    public List<CategoryModel> categories = new();
    public IEnumerable<int> selectedCategories = [];
    #endregion

    #region parameters
    [Parameter] public int ProductId { get; set; }
    #endregion

    #region constructors
    public AssignCategories(ICategoriesService categoriesService, IProductsService productsService) {
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        categories = await _categoriesService.GetAll();
        selectedCategories = (await _productsService.GetCategoriesAsync(ProductId)).Select(c => c.Id);
    }
    #endregion

    #region event handlers
    protected async Task OnCategoriesChanged(IEnumerable<int> categoryIds) => await _productsService.SetCategoriesAsync(ProductId, categoryIds);
    #endregion
}
