using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TiendaIna.Core.Models;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditImages : ComponentBase {
        #region SubClasses
        public class ImageData {
            public int Id { get; set; }
            public string? Url { get; set; }
            public string? SmallUrl { get; set; }
        }

        public class ImageMoveEventData {
            public int Id { get; set; }
            public int Position { get; set; }

            public ImageMoveEventData(int id, int pos) {
                Id = id;
                Position = pos;
            }
        }
        #endregion

        #region Propierties
        protected ImageData? SelectedImage { get; set; } = new();
        protected string? NewImageUrl { get; set; } = null;
        protected bool IsLoading { get; set; } = false;
        #endregion

        #region Parameters
        [Parameter] public SortedList<int, ImageData> Images { get; set; } = [];
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
                    SelectedImage = Images.First().Value;
            } finally {
                IsLoading = false;
            }
        }
        #endregion

        #region Event handlers
        public void OnSelectImage(ImageData imageModel) => SelectedImage = imageModel;
        #endregion
    }
}