using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Core;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ProductsList : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly DialogService _dialogService;
    private readonly NotificationService _notificationService;
    #endregion

    #region properties
    public List<ProductModel> originalProducts = [];

    public List<ProductModel>? Products { get; set; } = [];

    public RadzenDataGrid<ProductModel> Grid { get; set; }

    public bool IsLoading { get; set; } = false;
    #endregion

    #region constructors
    public ProductsList(IProductsService productsService, DialogService dialogService, NotificationService notificationService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        try {
            IsLoading = true;
            originalProducts = await _productsService.Get();
            Products = originalProducts.DeepClone();
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar los productos", ex);
        } finally {
            IsLoading = false;
        }
    }
    #endregion

    #region Methods
    private async Task Delete(int productId) {
        var confirm = await _dialogService.Confirm("¿Deseas eliminar este producto?", "Confirmar eliminación",
            new ConfirmOptions { OkButtonText = "Sí", CancelButtonText = "No" });

        if (confirm == true) {
            await _productsService.Delete(productId);
            Products = await _productsService.Get();
            await Grid.Reload();
            NotifySuccess("Producto eliminado exitosamente");
        }
    }
    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
