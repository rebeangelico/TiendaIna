using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImagesRadzen : ComponentBase {
        private readonly IProductsService _productsService;
        private readonly NotificationService _notificationService;

        public EditImagesRadzen(IProductsService productsService, NotificationService notificationService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        [Parameter] public ProductModel Product { get; set; } = new ProductModel();

        private string selectedImageUrl = "";
        private bool isLoading = false;

        protected override void OnParametersSet() {
            if (Product?.Images?.Any() == true) {
                selectedImageUrl = Product.Images.First();
            }
        }

        private void SelectImage(string imageUrl) {
            selectedImageUrl = imageUrl;
        }

        private async Task OnFileSelected(IEnumerable<IBrowserFile> files) {
            isLoading = true;

            try {
                foreach (var file in files.Take(10)) // Máximo 10 archivos
                {
                    // Validación de tamaño
                    if (file.Size > 5 * 1024 * 1024) {
                        _notificationService.Notify(new NotificationMessage {
                            Severity = NotificationSeverity.Warning,
                            Summary = "Archivo muy grande",
                            Detail = $"El archivo {file.Name} excede los 5MB"
                        });
                        continue;
                    }

                    // Validación de tipo
                    if (!file.ContentType.StartsWith("image/")) {
                        _notificationService.Notify(new NotificationMessage {
                            Severity = NotificationSeverity.Warning,
                            Summary = "Archivo no válido",
                            Detail = $"El archivo {file.Name} no es una imagen"
                        });
                        continue;
                    }

                    // Subida simulada del archivo
                    var imageUrl = await UploadImage(file);

                    // Agregar la URL al producto
                    if (!string.IsNullOrEmpty(imageUrl)) {
                        Product.Images ??= new List<string>();
                        Product.Images.Add(imageUrl);

                        // Establecer imagen seleccionada si no hay una aún
                        if (string.IsNullOrEmpty(selectedImageUrl)) {
                            selectedImageUrl = imageUrl;
                        }
                    }
                }

                // Actualizar el producto en el backend
                await _productsService.UpdateProduct(Product);
            } catch (Exception ex) {
                _notificationService.Notify(new NotificationMessage {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = $"Error al cargar imágenes: {ex.Message}"
                });
            } finally {
                isLoading = false;
                StateHasChanged();
            }
        }

        private async Task<string> UploadImage(IBrowserFile file) {
            try {
                var buffer = new byte[file.Size];
                await file.OpenReadStream().ReadAsync(buffer);

                // Simulación de URL base64 para mostrar la imagen directamente
                var base64 = Convert.ToBase64String(buffer);
                var imageUrl = $"data:{file.ContentType};base64,{base64}";

                return imageUrl;
            } catch (Exception ex) {
                Console.WriteLine($"Error al convertir imagen: {ex.Message}");
                return string.Empty;
            }
        }

        private void RemoveImage(string imageUrl) {
            if (Product.Images?.Contains(imageUrl) == true) {
                Product.Images.Remove(imageUrl);

                if (selectedImageUrl == imageUrl) {
                    selectedImageUrl = Product.Images.FirstOrDefault() ?? "";
                }

                StateHasChanged();
            }
        }

        private void MoveImageUp(string imageUrl) {
            if (Product.Images?.Contains(imageUrl) == true) {
                var index = Product.Images.IndexOf(imageUrl);
                if (index > 0) {
                    Product.Images.RemoveAt(index);
                    Product.Images.Insert(index - 1, imageUrl);
                    StateHasChanged();
                }
            }
        }

        private void MoveImageDown(string imageUrl) {
            if (Product.Images?.Contains(imageUrl) == true) {
                var index = Product.Images.IndexOf(imageUrl);
                if (index < Product.Images.Count - 1) {
                    Product.Images.RemoveAt(index);
                    Product.Images.Insert(index + 1, imageUrl);
                    StateHasChanged();
                }
            }
        }

        private async Task SaveChanges() {
            isLoading = true;
            try {
                await _productsService.UpdateProduct(Product);
                _notificationService.Notify(new NotificationMessage {
                    Severity = NotificationSeverity.Success,
                    Summary = "Éxito",
                    Detail = "Imágenes actualizadas correctamente"
                });
            } catch (Exception ex) {
                _notificationService.Notify(new NotificationMessage {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = $"Error al guardar: {ex.Message}"
                });
            } finally {
                isLoading = false;
            }
        }
    }
}