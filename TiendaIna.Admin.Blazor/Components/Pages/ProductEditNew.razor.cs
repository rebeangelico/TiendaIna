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
    private async Task OnImageFilesSelected(IEnumerable<IBrowserFile> files) {
        try {
            foreach (var file in files) {
                var mimeType = file.ContentType;
                using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                var newImage = await _imagesService.Add(imageBytes, mimeType);

                await _productsService.AddImage(productId, newImage.Id);
            }
            ShowNotification(NotificationSeverity.Success, "Éxito", "Imágenes agregadas correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al agregar imágenes: {ex.Message}");
        }
    }

    private async Task OnImageAddFromUrl(string url) {
        if (string.IsNullOrWhiteSpace(url)) return;
        try {
            var newImage = await _imagesService.Add(url);
            var imageProduct = await _productsService.AddImage(productId, newImage.Id);

            Images.Add(imageProduct.Key, GetImageData(imageProduct.Value));

            ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen agregada correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al agregar imagen: {ex.Message}");
        }
    }
    private async Task OnImageMove(EditImages.ImageMoveEventData imageMove){
        try {
            await _productsService.MoveImage(imageMove.Id, imageMove.OrderIndex);
            Images = GetImageData(await _productsService.GetImages(Product!.Id));

            ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la izquierda");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
        }
    }
    private async Task OnImageDelete(int productImageId)
    {
        try {
            await _productsService.RemoveImage(productImageId);
            ShowNotification(NotificationSeverity.Info, "Éxito", "Imagen eliminada correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
        }
    }
    #endregion

    #region helpers
    protected EditImages.ImageData GetImageData(ProductImageModel productImageModel) {
        return new EditImages.ImageData() {
            Id = productImageModel.Id,
            SmallUrl = productImageModel.SmallUrl,
            Url = productImageModel.Url,
            OrderIndex = productImageModel.OrderIndex
        };
    }

    protected SortedList<int, EditImages.ImageData> GetImageData(SortedList<int, ProductImageModel> productImages) {
        var productImageData = new SortedList<int, EditImages.ImageData>();
        foreach (var productImage in productImages) {
            productImageData.Add(productImage.Key, new EditImages.ImageData {
                Id = productImage.Value.Id,
                SmallUrl = productImage.Value.SmallUrl,
                Url = productImage.Value.Url,
                OrderIndex = productImage.Value.OrderIndex
            });
        }
        return productImageData;
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
