using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImagesRadzenPro : ComponentBase {
        private readonly IProductsService _productsService;
        private readonly IImagesService _imagesService;
        private readonly NotificationService _notificationService;

        public EditImagesRadzenPro(IProductsService productsService, IImagesService imagesService, NotificationService notificationService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        [Parameter] public ProductModel Product { get; set; } = new ProductModel();

        private List<ImageModel> Images { get; set; } = new List<ImageModel>();
        private string selectedImageUrl = "";
        private string newImageUrl = "";
        private bool isLoading = false;

        protected override async Task OnInitializedAsync() {
            await LoadImages();
        }

        private async Task LoadImages() {
            isLoading = true;

            try {
                if (Product?.Images?.Any() == true) {
                    Images = await _imagesService.GetListProduct(Product.Images);

                    // Seleccionar la primera imagen si hay alguna
                    if (Images.Any() && string.IsNullOrEmpty(selectedImageUrl)) {
                        selectedImageUrl = Images.First().Url;
                    }
                } else {
                    Images = new List<ImageModel>();
                }
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al cargar imágenes: {ex.Message}");
            } finally {
                isLoading = false;
            }
        }

        private void SelectImage(string imageUrl) {
            selectedImageUrl = imageUrl;
        }

        // Nueva funcionalidad: Agregar imagen desde URL
        private async Task AddImageFromUrl() {
            if (string.IsNullOrWhiteSpace(newImageUrl)) {
                ShowNotification(NotificationSeverity.Warning, "URL vacía", "Por favor ingrese una URL válida");
                return;
            }

            // Validar que sea una URL válida
            if (!Uri.TryCreate(newImageUrl, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)) {
                ShowNotification(NotificationSeverity.Warning, "URL inválida", "Por favor ingrese una URL válida (http o https)");
                return;
            }

            isLoading = true;

            try {
                // Crear modelo de imagen
                var imageModel = new ImageModel { Url = newImageUrl.Trim() };

                // Guardar en el backend y obtener el ID
                var imageId = await _imagesService.Add(imageModel);
                imageModel.Id = imageId;

                // Agregar a la lista de modelos
                Images.Add(imageModel);

                // Agregar el ID al producto
                Product.Images ??= new List<int>();
                Product.Images.Add(imageId);

                // Actualizar el producto en el backend inmediatamente
                await _productsService.Update(Product);

                // Establecer como imagen seleccionada si es la primera
                if (Images.Count == 1) {
                    selectedImageUrl = newImageUrl;
                }

                // Limpiar el campo de texto
                newImageUrl = "";

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
                foreach (var file in files.Take(10)) {
                    if (file.Size > 5 * 1024 * 1024) {
                        ShowNotification(NotificationSeverity.Warning, "Archivo muy grande", $"El archivo {file.Name} excede los 5MB");
                        continue;
                    }

                    if (!file.ContentType.StartsWith("image/")) {
                        ShowNotification(NotificationSeverity.Warning, "Archivo no válido", $"El archivo {file.Name} no es una imagen");
                        continue;
                    }

                    var imageUrl = await UploadImage(file);

                    if (!string.IsNullOrEmpty(imageUrl)) {
                        var imageModel = new ImageModel { Url = imageUrl };
                        var imageId = await _imagesService.Add(imageModel);
                        imageModel.Id = imageId;

                        Images.Add(imageModel);
                        Product.Images ??= new List<int>();
                        Product.Images.Add(imageId);

                        if (Images.Count == 1) {
                            selectedImageUrl = imageUrl;
                        }
                    }
                }

                await _productsService.Update(Product);
                ShowNotification(NotificationSeverity.Success, "Éxito", $"{files.Count()} imagen(es) agregada(s) correctamente");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al cargar imágenes: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task<string> UploadImage(IBrowserFile file) {
            try {
                var buffer = new byte[file.Size];
                await file.OpenReadStream().ReadAsync(buffer);

                var base64 = Convert.ToBase64String(buffer);
                var imageUrl = $"data:{file.ContentType};base64,{base64}";

                return imageUrl;
            } catch (Exception ex) {
                Console.WriteLine($"Error al convertir imagen: {ex.Message}");
                return string.Empty;
            }
        }

        private async Task RemoveImage(string imageUrl) {
            var imageToRemove = Images?.FirstOrDefault(i => i.Url == imageUrl);
            if (imageToRemove == null) return;

            isLoading = true;

            try {
                // Eliminar del backend
                await _imagesService.Delete(imageToRemove.Id);

                // Eliminar de la lista local
                Images.Remove(imageToRemove);
                Product.Images?.Remove(imageToRemove.Id);

                // Actualizar el producto
                await _productsService.Update(Product);

                // Actualizar imagen seleccionada
                if (selectedImageUrl == imageUrl) {
                    selectedImageUrl = Images.FirstOrDefault()?.Url ?? "";
                }

                ShowNotification(NotificationSeverity.Success, "Éxito", "Imagen eliminada correctamente");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al eliminar imagen: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task MoveImageUp(string imageUrl) {
            var index = Images?.FindIndex(i => i.Url == imageUrl) ?? -1;
            if (index <= 0) return;

            isLoading = true;

            try {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index - 1, image);

                // Reordenar IDs en Product.Images
                Product.Images = Images.Select(i => i.Id).ToList();

                // Actualizar en el backend inmediatamente
                await _productsService.Update(Product);

                ShowNotification(NotificationSeverity.Info, "Orden actualizado", "Imagen movida hacia la izquierda");
            } catch (Exception ex) {
                ShowNotification(NotificationSeverity.Error, "Error", $"Error al reordenar: {ex.Message}");
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task MoveImageDown(string imageUrl) {
            var index = Images?.FindIndex(i => i.Url == imageUrl) ?? -1;
            if (index < 0 || index >= Images.Count - 1) return;

            isLoading = true;

            try {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index + 1, image);

                // Reordenar IDs en Product.Images
                Product.Images = Images.Select(i => i.Id).ToList();

                // Actualizar en el backend inmediatamente
                await _productsService.Update(Product);

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
    }
}