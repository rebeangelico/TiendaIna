using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Collections.Immutable;
using TiendaIna.Core;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class BrandsEdit : ComponentBase {
    #region ReadOnly fields  (services)
    private readonly IBrandsService _brandsService;
    private readonly IImagesService _imagesService;
    private readonly NotificationService _notificationService;
    private readonly DialogService _dialogService;
    #endregion

    #region Fields
    public List<BrandModel> _originalBrands = [];
    #endregion

    #region Components
    public RadzenDataGrid<BrandModel?> Grid { get; set; }
    #endregion

    #region Properties
    public List<BrandModel> Brands { get; set; } = [];
    public BrandModel? BrandToInsert { get; set; } = null;
    public BrandModel? BrandToUpdate { get; set; } = null;
    public bool IsLoading { get; set; } = false;
    #endregion

    #region Constructors
    public BrandsEdit(IBrandsService brandsService, IImagesService imagesService, NotificationService notificationService, DialogService dialogService) : base() {
        _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }
    #endregion

    #region Overriden Methods
    protected override async Task OnInitializedAsync() {
        await LoadData();
    }
    #endregion

    #region Private Methods
    private async Task LoadData() {
        try {
            IsLoading = true;
            _originalBrands = await _brandsService.GetAll();
            Brands = _originalBrands.DeepClone();
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar marcas", ex);
        } finally {
            IsLoading = false;
        }
    }

    private async Task InsertRow() {
        BrandToInsert = new BrandModel();
        await Grid.InsertRow(BrandToInsert);
    }

    private async Task DeleteRow(BrandModel brand) {
        try {
            var result = await _dialogService.Confirm("¿Deseas eliminar esta marca?", "¿Estás seguro?",
                new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

            if (result == true) {
                await _brandsService.Delete(brand.Id);
                Brands.RemoveBy(b => b.Id == brand.Id);
                await Grid.Reload();
                NotifySuccess("Marca eliminada exitosamente");
            }
        } catch (Exception ex) {
            NotifyError("Error al Eliminar marca", ex);
        }
    }

    private async Task EditRow(BrandModel brand) {
        BrandToUpdate = brand;
        await Grid.EditRow(BrandToUpdate);
    }

    private void CancelEdit(BrandModel brand) {
        Brands?.RestoreFromList(b => b.Id == brand.Id, _originalBrands);
        Grid.CancelEditRow(brand);
        Grid.Reload();
        Reset();
    }

    private async Task SaveRow(BrandModel brand) {
        try {
            if (brand.Id > 0) {
                await _brandsService.Update(brand);
                NotifySuccess("Marca actualizada exitosamente");
            } else {
                var id = await _brandsService.Add(brand);
                brand.Id = id;
                _originalBrands.Add(brand.DeepClone());
                Brands.Add(brand);
                NotifySuccess("Marca insertada exitosamente");
            }
            await Grid.UpdateRow(brand);
            await Grid.Reload();
            Reset();
        } catch (Exception ex) {
            NotifyError("Error al actualizar marca", ex);
        }
    }

    void Reset() {
        BrandToInsert = null;
        BrandToUpdate = null;
    }
    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");

    #endregion
}
