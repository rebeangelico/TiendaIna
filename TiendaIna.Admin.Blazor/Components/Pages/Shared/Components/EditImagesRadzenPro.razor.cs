using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImagesRadzenPro : ComponentBase {
        #region fields
        private readonly IProductsService _productsService;
        private readonly IImagesService _imagesService;
        private readonly NotificationService _notificationService;
        #endregion

        #region Propierties
        private List<ImageModel> Images { get; set; } = [];
        private ImageModel? selectedImage = null;
        private string? newImageUrl = null;
        private bool isLoading = false;
        #endregion

        #region Parameters
        [Parameter] public ProductModel Product { get; set; } = new ProductModel();
        #endregion

        #region Constructors
        public EditImagesRadzenPro(IProductsService productsService, IImagesService imagesService, NotificationService notificationService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }
        #endregion

        #region overriden methods
        protected override async Task OnInitializedAsync() {
            await LoadImages();
        }
        #endregion

        #region private methdos
        private async Task LoadImages() {
            isLoading = true;

            try {
                Images = (await _productsService.GetImages(Product.Id)).ToList();
                // Seleccionar la primera imagen si hay alguna
                if (Images.Any() && selectedImage is null) {
                    selectedImage = Images.First();
                }
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al cargar imágenes: {ex.Message}");
            } finally {
                isLoading = false;
            }
        }

        private void SelectImage(ImageModel image) {
            selectedImage = image;
        }

        // Agregar imagen desde URL
        private async Task AddImageFromUrl() {
            if (string.IsNullOrWhiteSpace(newImageUrl)) {
                ShowNotification(NotificationSeverity.Warning, "URL vacía", "Por favor ingrese una URL válida");
                return;
            }

            if (!Uri.TryCreate(newImageUrl, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)) {
                ShowNotification(NotificationSeverity.Warning, "URL inválida", "Por favor ingrese una URL válida (http o https)");
                return;
            }

            isLoading = true;

            try {
                // Guardar en el backend y obtener el ID
                var image = await _imagesService.Add(newImageUrl);
                await _productsService.AddImage(Product.Id, image.Id);

                // Agregar a la lista de modelos
                Images.Add(image);

                // Establecer como imagen seleccionada si es la primera
                if (Images.Count == 1) {
                    selectedImage = image;
                }

                // Limpiar el campo de texto
                newImageUrl = null;

                ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen agregada correctamente");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al agregar imagen: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task OnFileSelected(IEnumerable<IBrowserFile> files) {
            isLoading = true;

            try {
                /*
                foreach (var file in files.Take(10)) {
                    if (file.Size > 5 * 1024 * 1024) {
                        ShowNotification(NotificationSeverity.Warning, "Archivo muy grande", $"El archivo {file.Name} excede los 5MB");
                        continue;
                    }

                    if (!file.ContentType.StartsWith("image/")) {
                        ShowNotification(NotificationSeverity.Warning, "Archivo no válido", $"El archivo {file.Name} no es una imagen");
                        continue;
                    }

                    
                    var image = await _imagesService.Add(stream, file.ContentType);

                    if (Images.Count == 1) {
                        selectedImage = image;
                    }
                }
                */

                ShowNotification(NotificationSeverity.Success, "Éxito", $"{files.Count()} imagen(es) agregada(s) correctamente");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al cargar imágenes: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task RemoveImage(int id) {
            isLoading = true;

            try {
                // Eliminar del backend
                await _productsService.RemoveImage(Product.Id, id);
                await _imagesService.Delete(id);

                // Eliminar de la lista local
                Images.Remove(im => im.Id == id);

                // Actualizar imagen seleccionada
                if (selectedImage?.Id == id)
                    selectedImage = Images.FirstOrDefault();

                ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen eliminada correctamente");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al eliminar imagen: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task MoveImageUp(int id) {
            var index = Images?.FindIndex(i => i.Id == id) ?? -1;
            if (index <= 0) return;

            isLoading = true;

            try {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index - 1, image);

                ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la izquierda");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task MoveImageDown(int id) {
            var index = Images?.FindIndex(i => i.Id == id) ?? -1;
            if (index < 0 || index >= Images.Count - 1) return;

            isLoading = true;

            try {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index + 1, image);

                ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la derecha");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private void ShowNotification(NotificationSeverity severity, string summary, string detail) {
            _notificationService.Notify(new NotificationMessage {
                Severity = severity,
                Summary = summary,
                Detail = detail,
                Duration = 4000
            });
        }
        #endregion
    }
}