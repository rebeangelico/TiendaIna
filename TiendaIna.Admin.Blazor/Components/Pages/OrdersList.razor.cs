using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class OrdersList : ComponentBase {
    #region fields
    private readonly IOrdersService _ordersService;
    private readonly DialogService _dialogService;
    private readonly NotificationService _notificationService;
    #endregion

    #region properties
    public List<OrderModel> originalOrders = [];

    public List<OrderModel>? Orders { get; set; } = [];

    public RadzenDataGrid<OrderModel> Grid { get; set; }

    public bool IsLoading { get; set; } = false;
    #endregion

    #region constructors
    public OrdersList(IOrdersService ordersService, DialogService dialogService, NotificationService notificationService) : base() {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        try {
            IsLoading = true;
            originalOrders = await _ordersService.GetAll();
            Orders = originalOrders.DeepClone();
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar los pedidos", ex);
        } finally {
            IsLoading = false;
        }
    }
    #endregion

    #region Methods
    private async Task Delete(int orderId) {
        var confirm = await _dialogService.Confirm("¿Deseas eliminar este pedido?", "Confirmar eliminación",
            new ConfirmOptions { OkButtonText = "Sí", CancelButtonText = "No" });

        if (confirm == true) {
            await _ordersService.Delete(orderId);
            Orders = await _ordersService.GetAll();
            await Grid.Reload();
            NotifySuccess("Pedido eliminado exitosamente");
        }
    }
    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
