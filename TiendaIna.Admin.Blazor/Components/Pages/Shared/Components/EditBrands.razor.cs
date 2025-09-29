using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditBrands : ComponentBase {
        private readonly IBrandsService _brandsService;


        public EditBrands(IBrandsService brandsService) {
            _brandsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        }

        RadzenDataGrid<BrandModel>? grid;
        BrandModel brandToInsert;
        List<BrandModel>? brands;
        int nextId = 1;

        protected override async Task OnInitializedAsync() {
            brands = await _brandsService.GetAll();
        }

        async Task EditRow(BrandModel item) {
            await grid.EditRow(item);
        }

        async Task SaveRow(BrandModel item) {
            await grid.UpdateRow(item);
        }

       async Task OnUpdateRow(BrandModel Entity) {
             await _brandsService.Update(Entity);
            Console.WriteLine($"Item actualizado: {Entity.Name}");
        }

        void CancelEdit(BrandModel Entity) {
            grid?.CancelEditRow(Entity);
        }

        async Task DeleteRow(BrandModel Entity) {
            brands?.Remove(Entity);
            await grid?.Reload();
            await _brandsService.Delete(Entity.Id);
        }

        async Task InsertRow() {
            brandToInsert = new BrandModel();
            await grid.InsertRow(brandToInsert);
        }

        async Task OnCreateRow(BrandModel item) {
            //await grid.RowCreate(item);
            //await _brandsService.Add(item);
            Console.WriteLine($"Nuevo item creado: {item.Name}");
        }


        #region helpers

        #endregion
    }
}