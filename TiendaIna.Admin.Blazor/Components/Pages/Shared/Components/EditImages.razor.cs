using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImages : ComponentBase {
        #region SubClasses
        public class ImageMoveEventData {
            public int ImageId { get; set; }
            public int Position { get; set; }

            public ImageMoveEventData(int imageId, int pos) {
                ImageId = imageId;
                Position = pos;
            }
        }
        #endregion

        #region Propierties
        protected ImageModel? SelectedImage { get; set; } = new();
        protected string? NewImageUrl { get; set; } = null;
        protected bool IsLoading { get; set; } = false;
        #endregion

        #region Parameters
        [Parameter] public ProductModel Product { get; set; } = new ProductModel();
        [Parameter] public List<ImageModel> Images { get; set; } = [];
        [Parameter] public EventCallback<int> OnDelete { get; set; }
        [Parameter] public EventCallback<ImageMoveEventData> OnMove { get; set; }
        [Parameter] public EventCallback<string> OnAddFromUrl { get; set; }
        [Parameter] public EventCallback<IEnumerable<IBrowserFile>> OnFilesSelected { get; set; }
        #endregion

        #region Constructors
        public EditImages() { }
        #endregion

        #region Overriden methods
        protected override void OnInitialized() {
            LoadImages();
        }
        #endregion

        #region Helper methods
        private void LoadImages() {
            IsLoading = true;
            try {
                if (Images?.Any() is true && SelectedImage is null)
                    SelectedImage = Images.First();
            } finally {
                IsLoading = false;
            }
        }
        #endregion

        #region Event handlers
        public void OnSelectImage(ImageModel imageModel) => SelectedImage = imageModel;
        #endregion
    }
}