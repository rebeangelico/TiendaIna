using Microsoft.AspNetCore.Components;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Web.Blazor.Components.Pages;
public partial class ProductsCatalog : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly ICategoriesService _categoriesService;
    private readonly DialogService _dialogService;
    private readonly NotificationService _notificationService;
    #endregion

    #region properties

    public List<ProductModel>? Products { get; set; }
    private IEnumerable<ProductModel> pagedProducts = [];

    private int pageSize = 9;
    private int currentPage = 0;
    public bool IsLoading { get; set; } = false;
    #endregion

    #region constructors
    public ProductsCatalog(IProductsService productsService, ICategoriesService categoriesService, DialogService dialogService, NotificationService notificationService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        try {
            IsLoading = true;
            Products = await _productsService.Get();
            UpdatePagedProducts();
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar los productos", ex);
        } finally {
            IsLoading = false;
        }
    }
    #endregion
    #region methods
    public void AddToCart(int productId, int amount) {  }
    private void OnPageChanged(PagerEventArgs args) {
        currentPage = args.PageIndex;
        UpdatePagedProducts();
    }

    private void UpdatePagedProducts() {
        pagedProducts = Products!
            .Where(p => p != null)
            .Skip(currentPage * pageSize)
            .Take(pageSize);
    }

    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
