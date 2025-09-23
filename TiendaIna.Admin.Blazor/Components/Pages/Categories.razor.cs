using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class CategoriesList : ComponentBase {
    #region fields
    private readonly ICategoriesService _categoriesService;
    #endregion

    #region properties
    public List<CategoryModel>? Categories { get; set; }
    #endregion

    #region constructors
    public CategoriesList(ICategoriesService categoriesService) : base() {
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Categories = await _categoriesService.GetAll();
    }
    #endregion
}
