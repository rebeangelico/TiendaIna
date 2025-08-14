using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImages : ComponentBase {
        [Parameter] public ProductModel Product { get; set; } = null!;

        public string? SelectedImage { get; private set; }
        public bool ShowModal { get; private set; }

        // Método para mostrar el modal con la imagen seleccionada
        public void OnShowImageModal(string image) {
            SelectedImage = image;
            ShowModal = true;
            StateHasChanged(); // Importante para actualizar la UI
        }

        // Método para cerrar el modal
        public void OnCloseModal() {
            SelectedImage = null;
            ShowModal = false;
            StateHasChanged(); // Importante para actualizar la UI
        }

        // Método para eliminar una imagen
        public void OnDeleteImage(string image) {
            Product.Images?.Remove(image);
            StateHasChanged(); // Importante para actualizar la UI
        }
    }
}