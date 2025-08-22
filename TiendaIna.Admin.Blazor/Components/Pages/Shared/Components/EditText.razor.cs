using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditText : ComponentBase {

        #region fields
        #endregion

        #region Parameters
        [Parameter] public string Value { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public string Placeholder { get; set; } = "Escribí aquí...";
        [Parameter] public int Rows { get; set; } = 5;
        [Parameter] public string? CssClass { get; set; }
        [Parameter] public bool Disabled { get; set; } = false;

        #endregion

        #region Methods
        // Método para manejar el cambio de valor
        protected async Task OnValueChanged(string newValue) {
            Value = newValue;
            await ValueChanged.InvokeAsync(newValue);
            StateHasChanged();
        }

        // Método para limpiar el texto
        public async Task Clear() {
            await OnValueChanged(string.Empty);
        }

        // Método para establecer un valor específico
        public async Task SetValue(string newValue) {
            await OnValueChanged(newValue);
        }
        #endregion
    }
}
