using Microsoft.AspNetCore.Components;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {
    public partial class EditNumber : ComponentBase {


        #region fields
        private string CurrencyFormat => $"{CurrencySymbol}#,##0.{new string('0', Decimals)}";
        #endregion

        #region Parameters
        [Parameter] public decimal Value { get; set; }
        [Parameter] public EventCallback<decimal> ValueChanged { get; set; }
        [Parameter] public string Placeholder { get; set; } = "Ingrese un monto";
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public string CssClass { get; set; } = "form-control";
        [Parameter] public int Decimals { get; set; } = 2;
        [Parameter] public string CurrencySymbol { get; set; } = "$";
        [Parameter] public decimal Step { get; set; } = 0.01m;

        #endregion

        #region Methods

        #endregion
    }
}
