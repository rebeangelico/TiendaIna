using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Collections.Immutable;
using TiendaIna.Core;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditCategories : ComponentBase {
        #region Fields
        private readonly ICategoriesService _categoriesService;
        private readonly NotificationService _notificationService;
        private readonly DialogService _dialogService;
        #endregion

        #region Constructors
        public EditCategories(ICategoriesService categoriesService, NotificationService notificationService, DialogService dialogService) {
            _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }
        #endregion

        #region Properties
        private RadzenDataGrid<CategoryModel> grid = new();
        private List<CategoryModel> categories = [];
        private List<CategoryModel> originalCategories = [];
        private IEnumerable<CategoryModel> parentCategories = [];
        private CategoryModel? categoryToInsert = null;
        private CategoryModel? categoryToUpdate = null;
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
                originalCategories = await _categoriesService.GetAll();
                categories = originalCategories.DeepClone();
                parentCategories = categories.Where(c => c.ParentCategoryId == null);
                StateHasChanged();
            } catch (Exception ex) {
                NotifyError("Error al cargar categorías", ex);
            } finally {
                isLoading = false;
            }
        }

        private async Task InsertRow() {
            categoryToInsert = new CategoryModel();
            await grid.InsertRow(categoryToInsert);
        }

        private async Task DeleteRow(CategoryModel category) {
            try {
                var result = await _dialogService.Confirm("¿Deseas eliminar esta categoría?", "¿Estás seguro?",
                    new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

                if (result == true) {
                    await _categoriesService.Delete(category.Id);
                    categories.RemoveBy(c => c.Id == category.Id);
                    await grid.Reload();
                    NotifySuccess("Categoría eliminada exitosamente");
                }
            } catch (Exception ex) {
                NotifyError("Error al Eliminar categoría", ex);
            }
        }

        private async Task EditRow(CategoryModel category) {
            categoryToUpdate = category;
            await grid.EditRow(categoryToUpdate);
        }

        private void CancelEdit(CategoryModel category) {
            categories.RestoreFromList(c => c.Id == category.Id, originalCategories);
            grid.CancelEditRow(category);
            grid.Reload();
            Reset();
        }

        private async Task SaveRow(CategoryModel category) {
            try {
                if (category.Id > 0) {
                    await _categoriesService.Update(category);
                    NotifySuccess("Categoría actualizada exitosamente");
                } else {
                    var id = await _categoriesService.Add(category);
                    category.Id = id;
                    originalCategories.Add(category.DeepClone());
                    categories.Add(category);
                    NotifySuccess("Categoría insertada exitosamente");
                }
                await grid.UpdateRow(category);
                await grid.Reload();
                Reset();
            } catch (Exception ex) {
                NotifyError("Error al actualizar categoría", ex);
            }
        }

        void Reset() {
            categoryToInsert = new();
            categoryToUpdate = new();
        }
        #endregion

        #region Helpers
        private void NotifySuccess(string message) =>
            _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

        private void NotifyError(string context, Exception ex) =>
            _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");

        private string? GetParentCategoryName(int? parentId) {
            if (parentId == null) return null;
            return categories?.FirstOrDefault(c => c.Id == parentId)?.Name;
        }
        #endregion
    }
}