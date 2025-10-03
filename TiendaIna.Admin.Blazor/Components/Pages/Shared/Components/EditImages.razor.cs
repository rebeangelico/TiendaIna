using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImages : ComponentBase {
        private readonly IImagesService _imagesService;
        public EditImages(IImagesService imagesService) { 
        _imagesService = imagesService;
        }

        [Parameter] public ProductModel Product { get; set; } = null!;

        public List<ImageModel> images { get; set; }
        public string? SelectedImage { get; private set; }
        public bool ShowModal { get; private set; }

        public void OnShowImageModal(string image) {
            SelectedImage = image;
            ShowModal = true;
            images = _imagesService.GetListProduct(Product.Images).Result;
            StateHasChanged();
        }

        public void OnCloseModal() {

            SelectedImage = null;
            ShowModal = false;
            StateHasChanged(); 
        }

        public void OnDeleteImage(int idImage) {
            Product.Images?.Remove(idImage);
            StateHasChanged(); 
        }
    }
}