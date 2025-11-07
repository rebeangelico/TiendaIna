using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;


namespace TiendaIna.Web.Blazor.Components.Pages;
public partial class ProductsCatalog : ComponentBase {

    #region SubClass
    public class ProductFiltersItems {
        public string? FilterText { get; set; } = "";
        public Action? Action { get; set; }

    }
    #endregion

    #region fields
    private readonly IProductsService _productsService;
    private readonly ICategoriesService _categoriesService;
    private readonly IBrandsService _brandsService;
    private readonly DialogService _dialogService;
    private readonly NotificationService _notificationService;
    #endregion

    #region properties

    public List<ProductModel>? Products { get; set; }
    public List<CategoryModel> Categories { get; set; } = [];
    public IEnumerable<ProductModel>? FilteredProducts { get; set; }
    public IEnumerable<ProductModel> PagedProducts = [];

    public List<ProductFiltersItems> FiltersApplied { get; set; } = [];
    public IEnumerable<RadzenBreadCrumbItem> BreadCrumbItems =>
    FiltersApplied.Select(f => new RadzenBreadCrumbItem {
        Text = f.FilterText
    });

    public int? BrandId;
    public int? CategoryId;

    private List<BrandModel>? Brands { get; set; }

    private int _pageSize = 9;
    private int _currentPage = 0;
    public bool IsLoading { get; set; } = false;
    #endregion

    #region constructors
    public ProductsCatalog(IProductsService productsService, ICategoriesService categoriesService, IBrandsService brandsService, DialogService dialogService, NotificationService notificationService) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
        _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        Products = await _productsService.Get();
        Categories = await _categoriesService.GetAll();
        SetFiltersFromUrl();
        ApplyFilters();
        StateHasChanged();
        IsLoading = false;
        await base.OnInitializedAsync();
    }
    #endregion

    #region methods
    public void AddToCart(int productId, int amount) { } //implementar
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

    #endregion

    #region Filters Methods
    private void ApplyFilters() {
        IsLoading = true;
        FiltersApplied.Clear();

        FilteredProducts = Products.DeepClone();

        if (CategoryId is not null) {
            FilteredProducts = FilteredProducts?
                .Where(p => p.Categories != null && p.Categories.Any(c => c.Id == CategoryId));

            FiltersApplied.Add(new ProductFiltersItems {
                FilterText = $"Categoría: {GetCategoryName(CategoryId.Value)}",
                Action = () =>
                {
                    CategoryId = null;
                    ApplyFilters();
                }
            });
        }

        if (BrandId is not null) {
            FilteredProducts = FilteredProducts?
                .Where(p => p.BrandId == BrandId);

            FiltersApplied.Add(new ProductFiltersItems {
                FilterText = $"Marca: {GetBrandName(BrandId.Value)}",
                Action = () =>
                {
                    BrandId = null;
                    ApplyFilters();
                }
            });
        }

        _currentPage = 0;
        UpdatePagedProducts();
        IsLoading = false;
        StateHasChanged();
    }
    private void FilterByBrand(int? brandId) {
        BrandId = brandId;
        ApplyFilters();
    }

    private void FilterByCategory(int? categoryId) {
        CategoryId = categoryId;
        ApplyFilters();
    }

    private void ResetFilters() {
        BrandId = null;
        CategoryId = null;
        StateHasChanged();
    }

    void RemoveFilter(ProductFiltersItems filtro) {
        filtro.Action?.Invoke();
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
    public string GetBrandName(int id) => _brandsService.Get(id).Result.Name;
    public string GetCategoryName(int id) => _categoriesService.Get(id).Result.Name;
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
