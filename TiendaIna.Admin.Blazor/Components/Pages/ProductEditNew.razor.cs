using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ProductEditNew : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly ICategoriesService _categoriesService;
    private readonly IBrandsService _brandsService;
    private readonly IImagesService _imagesService;
    private readonly NavigationManager _navigationManager;
    #endregion

    #region parameters
    [Parameter] public int productId { get; set; }
    #endregion

    #region properties

    public ProductModel? Product { get; set; }

    public List<CategoryModel> CategoriesData { get; set; }
    public IEnumerable<int>? SelectedCategoriesIds { get; set; }
    #endregion

    #region constructors
    public ProductEditNew(IProductsService productsService, ICategoriesService categoriesService, IBrandsService brandsService, IImagesService imagesService, NavigationManager navigationManager) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Product = await _productsService.Get(productId);
        CategoriesData = (await _categoriesService.GetAll());

    }

    #endregion

    #region Categories


    #endregion

    void NavegarA(string url) {
        _navigationManager.NavigateTo(url);
    }
    //vamos a atener un metodo sabe changes, que va a a impactar todos los cambios hechos en producto
    //tambien uno que confirme o el mismo que registe la tarea completada

}
