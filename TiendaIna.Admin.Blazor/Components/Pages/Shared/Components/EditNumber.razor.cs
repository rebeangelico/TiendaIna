using Microsoft.AspNetCore.Components;


namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components {

    public partial class EditNumber<TValue> : ComponentBase {
        #region Fields
        private string CurrencyFormat => $"{CurrencySymbol}#,##0.{new string('0', Decimals)}";
        #endregion

        #region Parameters
        [Parameter] public TValue Value { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public string Placeholder { get; set; } = "Ingrese un monto";
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public string CssClass { get; set; } = "form-control";
        [Parameter] public int Decimals { get; set; } = 2;
        [Parameter] public string CurrencySymbol { get; set; } = "$";
        [Parameter] public decimal StepDecimal { get; set; } = 0.01m;
        [Parameter] public TValue MinValue { get; set; }
        [Parameter] public TValue MaxValue { get; set; }
        [Parameter] public bool ShowUpDown { get; set; } = true;
        #endregion

        #region Methods
        private decimal GetMinValue() {
            return MinValue Convert.ToDecimal();
        }

        private TValue GetMaxValue() {
            return MaxValue;
        }

        private Type GetUnderlyingType() {
            var type = typeof(TValue);

            // Si es nullable, obtener el tipo subyacente
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                return Nullable.GetUnderlyingType(type);
            }

            return type;
        }

        private decimal GetStepValue() {
            var underlyingType = GetUnderlyingType();

            // Si es int, el step debería ser 1
            if (underlyingType == typeof(int) || underlyingType == typeof(long)) {
                return 1m;
            }

            return StepDecimal;
        }

        private string GetFormatString() {
            var underlyingType = GetUnderlyingType();

            // Solo aplicar formato de moneda para tipos decimales/float
            if (underlyingType == typeof(decimal) ||
                underlyingType == typeof(double) ||
                underlyingType == typeof(float)) {
                return CurrencyFormat;
            }

            // Para enteros, formato sin decimales
            return "N0";
        }
        #endregion
    }
}