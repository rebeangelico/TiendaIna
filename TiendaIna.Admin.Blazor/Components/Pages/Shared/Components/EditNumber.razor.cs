using Microsoft.AspNetCore.Components;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {

    public partial class EditNumber<TValue> : ComponentBase {
        #region Fields
        private string CurrencyFormat => $"{CurrencySymbol}#,##0.{new string('0', Decimals)}";
        #endregion

        #region Parameters
        [Parameter] public TValue? Value { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public string? Placeholder { get; set; }
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public string CssClass { get; set; } = "form-control";
        [Parameter] public int Decimals { get; set; } = 2;
        [Parameter] public string CurrencySymbol { get; set; } = "$";
        [Parameter] public decimal? Min { get; set; }
        [Parameter] public decimal? Max { get; set; }
        [Parameter] public bool ShowUpDown { get; set; } = true;
        [Parameter] public TValue? StepValue { get; set; }
        #endregion

        #region read-only properties
        public string Format => "";
        public string Step => StepValue?.ToString() ?? "1";
        #endregion
    }
}