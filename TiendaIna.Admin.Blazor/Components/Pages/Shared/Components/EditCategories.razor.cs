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
        private List<CategoryModel> originalCategories = new List<CategoryModel>();
        private IEnumerable<CategoryModel> parentCategories = new List<CategoryModel>();
        private CategoryModel? categoryToInsert = null;
        private CategoryModel? categoryToUpdate = null;
        private bool isLoading = false;

        protected override async Task OnInitializedAsync() {
            await LoadData();
        }

        private async Task LoadData() {
            try {
                isLoading = true;
                originalCategories = await _categoriesService.GetCategories();
                foreach (var originalCategory in originalCategories) {
                    categories.Add(originalCategory.Clone());
                }
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

        private async Task EditRow(CategoryModel category) {
            categoryToUpdate = category;
            await grid.EditRow(categoryToUpdate);
        }


        private async Task SaveRow(CategoryModel category) {
            try {
                if (category.Id > 0) {
                    await _categoriesService.UpdateCategory(category);
                    _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría actualizada exitosamente");
                } else {
                    var id = await _categoriesService.AddCategory(category);
                    category.Id = id;
                    originalCategories.Add(category.Clone());
                    categories.Add(category);
                    _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría insertada exitosamente");
                }
                await grid.UpdateRow(category);
                await grid.Reload();
                Reset();
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al actualizar categoría: {ex.Message}");
            }
        }

        private void CancelEdit(CategoryModel category) {
            RestoreCategoryInList(category);
            grid.CancelEditRow(category);
            grid.Reload();
            categoryToInsert = null;
            categoryToUpdate = null;

        }

        private async Task DeleteRow(CategoryModel category) {
            try {
                var result = await _dialogService.Confirm("¿Deseas eliminar esta categoría?", "¿Estás seguro?",
                    new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

                if (result == true) {
                    await _categoriesService.DeleteCategory(category.Id);
                    RemoveCategoryFromList(category);
                    await grid.Reload();
                    _notificationService.Notify(NotificationSeverity.Success, "Éxito", "Categoría eliminada exitosamente");
                }
            } catch (Exception ex) {
                _notificationService.Notify(NotificationSeverity.Error, "Error", $"Error al eliminar categoría: {ex.Message}");
            }
        }

        private string? GetParentCategoryName(int? parentId) {
            if (parentId == null) return "Sin categoría padre";
            return categories?.FirstOrDefault(c => c.Id == parentId)?.Name;
        }

        #region helpers
        private void RestoreCategoryInList(CategoryModel category) {
            if (category is null) throw new ArgumentNullException(nameof(category));
            var originalCategory = originalCategories.Find(c => c.Id == category.Id);
            if (originalCategory is null) return;
            var ix = RemoveCategoryFromList(category);
            categories.Insert(ix, originalCategory.Clone());
        }

        private int RemoveCategoryFromList(CategoryModel category) {
            if (category is null) throw new ArgumentNullException(nameof(category));
            var ix = categories.FindIndex(c => c.Id == category.Id);
            if (ix < 0) return -1;
            categories.RemoveAt(ix);
            return ix;
        }
        #endregion
    }
}