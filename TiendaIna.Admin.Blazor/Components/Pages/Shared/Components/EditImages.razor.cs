using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImages : ComponentBase {
        [Parameter] public ProductModel Product { get; set; } = null!;

        public string? SelectedImage { get; private set; }
        public bool ShowModal { get; private set; }

        public void OnShowImageModal(string image) {
            SelectedImage = image;
            ShowModal = true;
            StateHasChanged();
        }

        public void OnCloseModal() {

            SelectedImage = null;
            ShowModal = false;
            StateHasChanged(); 
        }

        public void OnDeleteImage(string image) {
            Product.Images?.Remove(image);
            StateHasChanged(); 
        }
    }
}