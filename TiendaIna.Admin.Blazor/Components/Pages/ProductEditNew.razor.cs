using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Radzen;
using System.Threading.Tasks;
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
    private readonly NotificationService _notificationService;
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
    public ProductEditNew(IProductsService productsService, ICategoriesService categoriesService, IBrandsService brandsService, IImagesService imagesService, NotificationService notificationService, NavigationManager navigationManager) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        Product = await _productsService.Get(productId);
        CategoriesData = (await _categoriesService.GetAll());
        SelectedCategoriesIds = (await _productsService.GetCategoriesAsync(productId)).Select(c => c.Id);

    }

    #endregion

    #region Methods

    void NavegarA(string url) {
        _navigationManager.NavigateTo(url);
    }
    public async Task SaveChanges() {
        try {
            await _productsService.SetCategoriesAsync(productId, SelectedCategoriesIds);
            await _productsService.Update(Product);

            _notificationService.Notify(new NotificationMessage {
                Severity = NotificationSeverity.Success,
                Summary = "Cambios guardados",
                Detail = "El producto fue actualizado correctamente.",
                Duration = 4000
            });
                NavegarA("/products");

        } catch (Exception ex) {
            _notificationService.Notify(new NotificationMessage {
                Severity = NotificationSeverity.Error,
                Summary = "Error al guardar",
                Detail = $"Ocurrió un problema: {ex.Message}",
                Duration = 6000
            });
        }
    }

    #endregion
}
