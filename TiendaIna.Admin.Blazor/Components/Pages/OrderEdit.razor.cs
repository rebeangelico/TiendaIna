using Microsoft.AspNetCore.Components;
using Radzen;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class OrderEdit : ComponentBase {

    #region fields
    private readonly IProductsInfoService _productsInfoService;
    private readonly IOrdersService _ordersService;
    private readonly IPaymentsService _paymentsService;
    private readonly IClientsService _clientsService;
    private readonly NavigationManager _navigationManager;
    private readonly NotificationService _notificationService;
    #endregion

    #region parameters
    [Parameter] public int orderId { get; set; }
    #endregion

    #region properties
    public OrderModel Order { get; set; }
    public List<PaymentModel> PaymentsData { get; set; }
    public ClientModel Client { get; set; }

    public IEnumerable<ProductInfoModel> ProductsInfo { get; set; }
    public List<int> PruductsInfoIds { get; set; }

    #endregion

    #region constructors
    public OrderEdit(IProductsInfoService productsInfoService, IOrdersService ordersService, IPaymentsService paymentsService, IClientsService clientsService, NotificationService notificationService, NavigationManager navigationManager) : base() {
        _productsInfoService = productsInfoService ?? throw new ArgumentNullException(nameof(productsInfoService));
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _paymentsService = paymentsService ?? throw new ArgumentNullException(nameof(paymentsService));
        _clientsService = clientsService ?? throw new ArgumentNullException(nameof(clientsService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync()
    {
        PaymentsData = await _paymentsService.GetFromOrder(orderId);

        if (orderId == 0)
        {
            // Crear nuevo pedido
            Order = new OrderModel();
        }
        else { 
            Order = await _ordersService.Get(orderId);

                if(Order == null) {
                    ShowNotification(
                        NotificationSeverity.Warning,
                        "Orden no encontrada",
                        $"La orden con ID {orderId} no existe."
                    );
                    NavigateTo("/orders");
                    return; 
                }
            ProductsInfo = await _productsInfoService.GetFromOrder(orderId);

            if (Order?.Client != null)
            {
                Client = await _clientsService.Get(Order.Client.Id);
            }
        }
    }

    #endregion

    #region page event handlers
    public async Task SaveChanges() {

        try {
            if (Order is null) throw new InvalidOperationException();

            if (orderId == 0) {
                var newOrderId = await _ordersService.Add(Order);

                foreach(var p in ProductsInfo) { 
                var newProductsInfoId = await _productsInfoService.Add(p);
                    PruductsInfoIds.Add(newProductsInfoId);
                }
                ShowNotification(NotificationSeverity.Success, "Pedido creado", "El pedido fue creado correctamente.");
            
            } else {
                await _ordersService.Update(Order);

                ShowNotification(NotificationSeverity.Success, "Cambios guardados", "El pedido fue actualizado correctamente.");
            }

            NavigateTo("/products");
        } catch (Exception ex) {
            ShowNotification(NotificationSeverity.Error, "Error al guardar", $"Ocurrió un problema: {ex.Message}");
        }
    }
    #endregion

    #region image event handlers

    #endregion

    #region helpers

    protected void NavigateTo(string url) => _navigationManager.NavigateTo(url);

    protected void ShowNotification(NotificationSeverity severity, string summary, string detail, int duration = 4000) {
        _notificationService.Notify(new NotificationMessage {
            Severity = severity,
            Summary = summary,
            Detail = detail,
            Duration = duration
        });
    }
    #endregion
}
