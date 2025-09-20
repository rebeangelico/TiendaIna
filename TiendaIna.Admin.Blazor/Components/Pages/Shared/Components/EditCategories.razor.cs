using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditCategories : ComponentBase {
        private readonly ICategoriesService _categoriesService;
        private readonly NotificationService _notificationService;
        private readonly DialogService _dialogService;

        public EditCategories(ICategoriesService categoriesService, NotificationService notificationService, DialogService dialogService) {
            _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        private RadzenDataGrid<CategoryModel> grid = new();
        private List<CategoryModel> categories = new List<CategoryModel>();
        private IEnumerable<CategoryModel> parentCategories = new List<CategoryModel>();
        private CategoryModel categoryToInsert = new();
        private CategoryModel categoryToUpdate = new();
        private bool isLoading = false;

        protected override async Task OnInitializedAsync() {
            await LoadData();
        }

        private async Task LoadData() {
            try {
                isLoading = true;
                categories = await _categoriesService.GetCategories();
                parentCategories = categories.Where(c => c.ParentCategoryId == null);
                StateHasChanged();
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al cargar categorías: {ex.Message}");
            } finally {
                isLoading = false;
            }
        }

        private async Task InsertRow() {
            categoryToInsert = new CategoryModel();
            await grid.InsertRow(categoryToInsert);
        }

        private async Task OnCreateRow(CategoryModel category) {
            try {
                await _categoriesService.AddCategory(category);
                categoryToInsert = new();
                await LoadData();
                _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría creada exitosamente");
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al crear categoría: {ex.Message}");
            }
        }

        private async Task EditRow(CategoryModel category) {
            categoryToUpdate = category;
            await grid.EditRow(category);
        }

        private async Task OnUpdateRow(CategoryModel category) {
            try {
                await _categoriesService.UpdateCategory(category);
                await LoadData();
                _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría actualizada exitosamente");
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al actualizar categoría: {ex.Message}");
            }
        }

        private async Task SaveRow(CategoryModel category) {
            await grid.UpdateRow(category);
        }

        private void CancelEdit(CategoryModel category) {
            grid.CancelEditRow(category);

            if (category == categoryToInsert) {
                categoryToInsert = new();
            }

            categoryToUpdate = new();
        }

        private async Task DeleteRow(CategoryModel category) {
            try {
                var result = await _dialogService.Confirm("¿Deseas eliminar esta categoría?", "¿Estás seguro?",
                    new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

                if (result == true) {
                    await _categoriesService.DeleteCategory(category.Id);
                    await LoadData();
                    _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría eliminada exitosamente");
                }
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al eliminar categoría: {ex.Message}");
            }
        }

        private string GetParentCategoryName(int? parentId) {
            if (parentId == null) return "Sin categoría padre";
            var parent = categories.FirstOrDefault(c => c.Id == parentId);
            return parent?.Name ?? "Categoría no encontrada";
        }
    }
}