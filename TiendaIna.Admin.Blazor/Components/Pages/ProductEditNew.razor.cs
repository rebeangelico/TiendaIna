using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core.Entities;
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

    public List<CategoryModel> CategoriesData { get; set; }
    public IEnumerable<int>? SelectedCategoriesIds { get; set; }


    public List<ImageModel> Images { get; set; } = [];

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

        Images = (await _productsService.GetImages(Product.Id)).ToList();

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
    #region Methods Images
    private async Task HandleRemoveImage(int id) {
        isLoading = true;
        try {
            await _productsService.RemoveImage(Product.Id, id);
            await _imagesService.Delete(id);
            Images.RemoveAll(img => img.Id == id);

            if (selectedImage?.Id == id)
                selectedImage = Images.FirstOrDefault();

            ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen eliminada correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al eliminar imagen: {ex.Message}");
        } finally {
            isLoading = false;
        }
    }

    private async Task HandleMoveImageUp(int id) {
        var index = Images.FindIndex(i => i.Id == id);
        if (index <= 0) return;

        isLoading = true;
        try {
            var img = Images[index];
            Images.RemoveAt(index);
            Images.Insert(index - 1, img);

            ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la izquierda");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
        } finally {
            isLoading = false;
        }
    }

    private async Task HandleMoveImageDown(int id) {
        var index = Images.FindIndex(i => i.Id == id);
        if (index < 0 || index >= Images.Count - 1) return;

        isLoading = true;
        try {
            var img = Images[index];
            Images.RemoveAt(index);
            Images.Insert(index + 1, img);

            ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la derecha");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
        } finally {
            isLoading = false;
        }
    }

    private async Task HandleAddImageFromUrl(string url) {
        if (string.IsNullOrWhiteSpace(url)) return;

        isLoading = true;
        try {
            // lógica para agregar imagen desde URL
            newImageUrl = null;
            ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen agregada correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al agregar imagen: {ex.Message}");
        } finally {
            isLoading = false;
        }
    }

    private async Task HandleFilesSelected(IEnumerable<IBrowserFile> files) {
        isLoading = true;
        try {
            // lógica para subir imágenes
            ShowNotification(NotificationSeverity.Success, "Éxito", $"{files.Count()} imagen(es) agregada(s)");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al subir imágenes: {ex.Message}");
        } finally {
            isLoading = false;
        }
    }

    private Task HandleSelectImage(ImageModel image) {
        selectedImage = image;
        return Task.CompletedTask;
    }


    private async Task RemoveImageAsync(int id) {
        try {
            await _productsService.RemoveImage(Product.Id, id);
            await _imagesService.Delete(id);

            Images.RemoveAll(im => im.Id == id);

            if (selectedImage?.Id == id)
                selectedImage = Images.FirstOrDefault();

            ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen eliminada correctamente");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error", $"Error al eliminar imagen: {ex.Message}");
        } finally {
            StateHasChanged();
        }
    }

    private void ShowNotification(NotificationSeverity severity, string summary, string detail) {
        _notificationService.Notify(new NotificationMessage {
            Severity = severity,
            Summary = summary,
            Detail = detail,
            Duration = 4000
        });
    }
    #endregion
}
