using Microsoft.AspNetCore.Components;
using Radzen;
using TiendaIna.Core.Entities;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Web.Blazor.Components.Pages;
public partial class ProductsCatalog : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly DialogService _dialogService;
    private readonly NotificationService _notificationService;
    #endregion

    #region properties

    public List<ProductModel>? Products { get; set;}
    public IEnumerable<ProductModel>? FilteredProducts { get; set; }
    public IEnumerable<ProductModel> PagedProducts = [];
    public int? BrandId;
    public int? CategoryId;

    private List<BrandModel>? Brands { get; set; }

    private int _pageSize = 9;
    private int _currentPage = 0;
    public bool IsLoading { get; set; } = false;
    #endregion

    #region constructors
    public ProductsCatalog(IProductsService productsService, DialogService dialogService, NotificationService notificationService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        Products = await _productsService.Get();
        SetFiltersFromUrl();
        ApplyFilters();
        StateHasChanged();
        IsLoading = false;
        await base.OnInitializedAsync();
    }
    #endregion

    #region methods
    public void AddToCart(int productId, int amount) {} //implementar
    private void ApplyFilters() {
        IsLoading = true;
        FilteredProducts = Products.DeepClone();
        if (CategoryId is not null)
            FilteredProducts = FilteredProducts?.Where(p => p.Categories != null && p.Categories.Any(c => c.Id == CategoryId));
        if (BrandId is not null)
            FilteredProducts = FilteredProducts?.Where(p => p.BrandId == BrandId);

        _currentPage = 0;
        UpdatePagedProducts();
        IsLoading = false;
        StateHasChanged();
    }
    private void OnPageChanged(PagerEventArgs args) {
        _currentPage = args.PageIndex;
        UpdatePagedProducts();
    }

    private void UpdatePagedProducts() {
        PagedProducts = FilteredProducts!
            .Where(p => p != null)
            .Skip(_currentPage * _pageSize)
            .Take(_pageSize);
    }

    private void FilterByBrand(int? brandId) {
        ResetFilters();
        BrandId = brandId;
        ApplyFilters();
    }

    private void FilterByCategory(int? categoryId) {
        ResetFilters();
        CategoryId = categoryId;
        ApplyFilters();
    }

    private void ResetFilters() {
        BrandId = null;
        CategoryId = null;
        StateHasChanged();
    }

    private void SetFiltersFromUrl() {
        var uri = new Uri(NavigationManager.Uri);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);

        if (int.TryParse(queryParams["brandId"], out var brandId))
            BrandId = brandId;
        if (int.TryParse(queryParams["categoryId"], out var categoryId))
            CategoryId = categoryId;
    }
    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
