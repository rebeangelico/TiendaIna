using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Admin.Blazor.Helpers;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditBrands : ComponentBase {
        private readonly IBrandsService _brandsService;
        private readonly NotificationService _notificationService;
        private readonly DialogService _dialogService;


        public EditBrands(IBrandsService brandsService, NotificationService notificationService, DialogService dialogService) {
            _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }
        #region Properties
        RadzenDataGrid<BrandModel> grid;
        private List<BrandModel> brands = [];
        private List<BrandModel> originalBrands = [];
        private BrandModel? brandToInsert = null;
        private BrandModel? brandToUpdate = null;
        private bool isLoading = false;
        #endregion

        #region Overriden Methods
        protected override async Task OnInitializedAsync() {
            await LoadData();
        }
        #endregion

        #region Private Methods
        private async Task LoadData() {
            try {
                isLoading = true;
                originalBrands = await _brandsService.GetAll();
                foreach (var originalCategory in originalBrands)
                    brands.Add(originalCategory.Clone());
                StateHasChanged();
            } catch (Exception ex) {
                NotifyError("Error al cargar marcas", ex);
            } finally {
                isLoading = false;
            }
        }

        private async Task InsertRow() {
            brandToInsert = new BrandModel();
            await grid.InsertRow(brandToInsert);
        }

        private async Task DeleteRow(BrandModel brand) {
            try {
                var result = await _dialogService.Confirm("¿Deseas eliminar esta marca?", "¿Estás seguro?",
                    new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

                if (result == true) {
                    await _brandsService.Delete(brand.Id);
                    brands.Remove(b => b.Id == brand.Id);
                    await grid.Reload();
                    NotifySuccess("Marca eliminada exitosamente");
                }
            } catch (Exception ex) {
                NotifyError("Error al Eliminar marca", ex);
            }
        }

        private async Task EditRow(BrandModel brand) {
            brandToUpdate = brand;
            await grid.EditRow(brandToUpdate);
        }

        private void CancelEdit(BrandModel brand) {
            brands.RestoreFromList(b => b.Id == brand.Id, originalBrands);
            grid.CancelEditRow(brand);
            grid.Reload();
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
                    originalBrands.Add(brand.Clone());
                    brands.Add(brand);
                    NotifySuccess("Marca insertada exitosamente");
                }
                await grid.UpdateRow(brand);
                await grid.Reload();
                Reset();
            } catch (Exception ex) {
                NotifyError("Error al actualizar marca", ex);
            }
        }

        void Reset() {
            brandToInsert = new();
            brandToUpdate = new();
        }
        #endregion

        #region Helpers
        private void NotifySuccess(string message) =>
            _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

        private void NotifyError(string context, Exception ex) =>
            _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");

        #endregion

    }
}