using Microsoft.AspNetCore.Components;

namespace TiendaIna.Admin.Blazor.Components.Pages.Shared.Components;

public partial class AssignCheckBox : ComponentBase {

    #region parameters
    [Parameter] public Dictionary<int, string>? Data { get; set; }
    [Parameter] public HashSet<int>? SelectedValues { get; set; }
    [Parameter] public EventCallback<HashSet<int>?> SelectedValuesChanged { get; set; }
    #endregion

    #region constructors
    public AssignCheckBox() {

    }
    #endregion

    #region methods

    protected bool IsSelected(int key) => SelectedValues?.Contains(key) ?? false;
    protected async Task OnChange(int key, bool isChecked) {
        if (isChecked) {
            SelectedValues?.Add(key);
        } else {
            if (IsSelected(key) is not true) return;
            SelectedValues?.Remove(key);
        }
        await SelectedValuesChanged.InvokeAsync(SelectedValues);
    }
    #endregion
}