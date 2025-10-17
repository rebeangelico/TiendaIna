using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Admin.Blazor.Components.Pages.Shared.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

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

    public List<CategoryModel>? CategoriesData { get; set; }
    public IEnumerable<int> SelectedCategoriesIds { get; set; } = [];


    public SortedList<int, EditImages.ImageData> Images { get; set; } = [];

    public ImageModel? selectedImage = null;
    public string? newImageUrl = null;
    public bool? isLoading = null;

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
        Images = GetImageData(await _productsService.GetImages(Product.Id));
    }

    #endregion

    #region page event handlers
    public async Task SaveChanges() {
        try {
            if (Product is null) throw new InvalidOperationException();

            await _productsService.SetCategoriesAsync(productId, SelectedCategoriesIds);
            await _productsService.Update(Product);

            ShowNotification(
                severity: NotificationSeverity.Success,
                summary: "Cambios guardados",
                detail: "El producto fue actualizado correctamente.");

            NavigateTo("/products");

        } catch (Exception ex) {
            ShowNotification(
                severity: NotificationSeverity.Error,
                summary: "Error al guardar",
                detail: $"Ocurrió un problema: {ex.Message}");
        }
    }
    #endregion
    
    #region image event handlers
    private void OnImageFilesSelected(IEnumerable<IBrowserFile> args)
    {
        throw new NotImplementedException();
    }
    private void OnImageAddFromUrl(string args)
    {
        throw new NotImplementedException();
    }
    private void OnImageMove(EditImages.ImageMoveEventData args)
    {
        throw new NotImplementedException();
    }
    private void OnImageDelete(int args)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region helpers
    protected SortedList<int, EditImages.ImageData> GetImageData(SortedList<int, ImageModel> images) {
        throw new NotImplementedException();
    }

    protected void NavigateTo(string url) => _navigationManager.NavigateTo(url);

    protected void ShowNotification(NotificationSeverity severity, string summary, string detail, int duration = 4000) {
        _notificationService.Notify(new NotificationMessage {
            Severity = severity,
            Summary = summary,
            Detail = detail,
            Duration = duration
        });
    }
    #endregion
}
