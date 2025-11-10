using Microsoft.AspNetCore.Components;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Web.Blazor.Components.Pages;
public partial class ProductDetails : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly NotificationService _notificationService;
    private readonly NavigationManager _navigationManager;
    #endregion

    #region Parameters
    [Parameter] public int Id { get; set; }

    #endregion

    #region properties
    private ProductModel? Product { get; set; }
    private string selectedImage;
    private bool IsLoading { get; set; } = false;

    private bool isSidebarOpen = false;
    #endregion

    #region constructors
    public ProductDetails(IProductsService productsService, NotificationService notificationService, NavigationManager navigationManager) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        try {
            IsLoading = true;
            Product = await _productsService.Get(Id);
            selectedImage = Product?.Images?.Values?.FirstOrDefault()?.Url ?? "placeholder.png";
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar los productos", ex);
        } finally {
            IsLoading = false;
        }
    }
    #endregion

    #region methods
    public void AddToCart(int productId, int quantity) {
    
    
    }
    void NavigateToCategory(int categoryId) {
        //implementar filtrado!!!
        _navigationManager.NavigateTo($"{categoryId}");
    }

    #endregion
    private void ToggleSidebar() {
        isSidebarOpen = !isSidebarOpen;
    }
    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
