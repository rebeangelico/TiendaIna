using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImagesRadzen : ComponentBase {
        private readonly IProductsService _productsService;
        private readonly IImagesService _imagesService;
        private readonly NotificationService _notificationService;

        public EditImagesRadzen(IProductsService productsService, IImagesService imagesService, NotificationService notificationService) {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            _imagesService = imagesService ?? throw new ArgumentNullException(nameof(imagesService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        [Parameter] public ProductModel Product { get; set; } = new ProductModel();

        private List<ImageModel> Images { get; set; } 
        private string selectedImageUrl = "";
        private bool isLoading = false;


        protected override async Task OnInitializedAsync() {
            isLoading = true;

            try {
                if (Product?.Images?.Any() == true) {
                    Images = await _imagesService.GetListProduct(Product.Images);
                } else {
                    Images = new List<ImageModel>();
                }
            } catch (Exception ex) {
                _notificationService.Notify(new NotificationMessage {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = $"Error al inicializar imágenes: {ex.Message}"
                });
            } finally {
                isLoading = false;
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

                    if (!string.IsNullOrEmpty(imageUrl)) {
                        // Crear modelo de imagen
                        var imageModel = new ImageModel { Url = imageUrl };

                        // Guardar en el backend y obtener el ID
                        var imageId = await _imagesService.Add(imageModel);
                        imageModel.Id = imageId;

                        // Agregar a la lista de modelos
                        Images ??= new List<ImageModel>();
                        Images.Add(imageModel);

                        // Agregar el ID al producto
                        Product.Images ??= new List<int>();
                        Product.Images.Add(imageId);

                        // Establecer imagen seleccionada si no hay una aún
                        if (string.IsNullOrEmpty(selectedImageUrl)) {
                            selectedImageUrl = imageUrl;
                        }
                    }
                }

                // Actualizar el producto en el backend
                await _productsService.Update(Product);
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
            var imageToRemove = Images?.FirstOrDefault(i => i.Url == imageUrl);
            if (imageToRemove != null) {
                Images.Remove(imageToRemove);
                Product.Images?.Remove(imageToRemove.Id);

                if (selectedImageUrl == imageUrl) {
                    selectedImageUrl = Images.FirstOrDefault()?.Url ?? "";
                }

                StateHasChanged();
            }
        }

        private void MoveImageUp(string imageUrl) {
            var index = Images?.FindIndex(i => i.Url == imageUrl) ?? -1;
            if (index > 0) {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index - 1, image);

                // Reordenar IDs en Product.Images
                Product.Images = Images.Select(i => i.Id).ToList();

                StateHasChanged();
            }
        }

        private void MoveImageDown(string imageUrl) {
            var index = Images?.FindIndex(i => i.Url == imageUrl) ?? -1;
            if (index >= 0 && index < Images.Count - 1) {
                var image = Images[index];
                Images.RemoveAt(index);
                Images.Insert(index + 1, image);

                // Reordenar IDs en Product.Images
                Product.Images = Images.Select(i => i.Id).ToList();

                StateHasChanged();
            }
        }

        private async Task SaveChanges() {
            isLoading = true;
            try {
                // Asegurar que los IDs estén sincronizados con el orden actual
                Product.Images = Images.Select(i => i.Id).ToList();

                await _productsService.Update(Product);
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