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
            public int OrderIndex { get; set; }
        }

        public class ImageMoveEventData {
            public int Id { get; set; }
            public int OrderIndex { get; set; }

            public ImageMoveEventData(int id, int orderIndex) {
                Id = id;
                OrderIndex = orderIndex;
            }
        }
        #endregion

        #region Propierties
        protected ImageData? SelectedImage { get; set; }
        protected string? NewImageUrl { get; set; }
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
        public void OnSelectImage(ImageData selectedImage) => SelectedImage = selectedImage;

        public async Task AddFromUrl() {
            IsLoading = true;
            try {
                await OnAddFromUrl.InvokeAsync(NewImageUrl);
                NewImageUrl = null;
            } finally {
                IsLoading = false;
            }
        }

        public async Task Delete(int id) {
            IsLoading = true;
            try {
                await OnDelete.InvokeAsync(id);
            } finally {
                IsLoading = false;
            }
        }

        public async Task FilesSelected(IEnumerable<IBrowserFile> files) {
            IsLoading = true;
            try {
                await OnFilesSelected.InvokeAsync(files);
            } finally {
                IsLoading = false;
            }
        }

        public async Task Move(ImageMoveEventData eventData) {
            IsLoading = true;
            try {
                await OnMove.InvokeAsync(eventData);
            } finally {
                IsLoading = false;
            }
        }
        #endregion
    }
}