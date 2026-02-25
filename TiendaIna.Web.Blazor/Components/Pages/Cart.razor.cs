using Microsoft.AspNetCore.Components;
using Radzen;
using TiendaIna.Core;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;
using TiendaIna.Infrastructure.Services;

namespace TiendaIna.Web.Blazor.Components.Pages;
public partial class Cart : ComponentBase {
    #region fields
    private readonly IProductsService _productsService;
    private readonly IOrdersService _ordersService;
    private readonly IPaymentsService _paymentsService;
    private readonly IClientsService _clientsService;
    private readonly ICartsService _cartsService;
    private readonly NotificationService _notificationService;
    private readonly NavigationManager _navigationManager;
    #endregion

    #region Parameters
    public CartModel? NewCart { get; set; }

    #endregion

    #region properties

    private ClientModel ClientForm { get; set; } = new();
    private string? SelectedPaymentMethod { get; set; }

    private bool IsLoading { get; set; } = false;
    private bool IsOrdering { get; set; } = false;

    private bool submitted = false;

    // ── Opciones de pago ────────────────────────────────────────────────── REEMPLAZAR POR UN ENUM!!!
    private record PaymentOption(string Label, string Icon, string Description);

    private readonly Dictionary<string, PaymentOption> PaymentMethods = new()
    {
        ["efectivo"] = new("Efectivo", "payments", "Pago en efectivo al retirar"),
        ["transferencia"] = new("Transferencia", "account_balance", "CBU / Alias bancario"),
        ["mercadopago"] = new("Mercado Pago", "credit_card", "Tarjeta, QR o billetera virtual"),
    };
    #endregion

    #region constructors
    public Cart(IProductsService productsService, ICartsService cartsService, IClientsService clientsService, IOrdersService ordersService, IPaymentsService paymentsService, NotificationService notificationService, NavigationManager navigationManager) : base() {
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        _cartsService = cartsService ?? throw new ArgumentNullException(nameof(cartsService));
        _clientsService = clientsService ?? throw new ArgumentNullException(nameof(clientsService));
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _paymentsService = paymentsService ?? throw new ArgumentNullException(nameof(paymentsService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }
    #endregion

    #region overriden methods
    protected override async Task OnInitializedAsync() {
        try {
            IsLoading = true;
            NewCart = await _cartsService.Get();
            StateHasChanged();
        } catch (Exception ex) {
            NotifyError("Error al cargar el carrito", ex);
        } finally {
            IsLoading = false;
        }
    }
    #endregion

    #region methods
    private void ChangeQuantity(ProductInfoModel item, int delta)
    {
        var newQty = item.Quantity + delta;
        if (newQty < 1) return;

        item.Quantity = newQty;
        RecalculateCart();
    }

    //Elimina un artículo del carrito y recalcula totales.
    private void RemoveItem(ProductInfoModel item)
    {
        NewCart?.Products?.Remove(item);
        RecalculateCart();
    }

    //Actualiza QuantityProducts y TotalPrice en el CartModel.
    private void RecalculateCart()
    {
        if (NewCart?.Products == null) return;

        NewCart.QuantityProducts = NewCart.Products.Sum(p => p.Quantity);
        NewCart.TotalPrice = NewCart.Products.Sum(p => p.Price * p.Quantity);

        StateHasChanged();
    }

    // ── Crear pedido ──────────────────────────────────────────────────────
    public async Task CreateOrder()
    {
        submitted = true;

        if (!IsFormValid()) return;

        try
        {
            IsOrdering = true;

            // 1. Resolver cliente (crear si no existe)
            var client = await ResolveClientAsync();

            // 2. Construir el modelo de la orden
            var order = BuildOrderModel(client);

            // 3. Persistir la orden a través del servicio
            var orderId = await _ordersService.Add(order);
            var createdOrder = await _ordersService.Get(orderId);

            // 4. Construir y persistir el pago inicial
            var payment = BuildPaymentModel(createdOrder.Id, client.Id);
            var newPaymentId = await _paymentsService.Add(payment);

            // 5. Notificar y navegar a la confirmación
            NotifySuccess("¡Pedido creado con éxito!"); 




            /// agregar pagina de detalle de pedido!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //NavigationManager.NavigateTo($"/order/{createdOrder.Id}");





        }
        catch (Exception ex)
        {
            NotifyError("Error al crear el pedido", ex);
        }
        finally
        {
            IsOrdering = false;
        }
    }

    // Busca el cliente por email; si no existe lo crea.
    // Ajustar la lógica según el contrato de IClientsService.

    private async Task<ClientModel> ResolveClientAsync()
    {
        var existing = await _clientsService.GetByEmail(ClientForm.Email!);
        if (existing != null) return existing;

         var id = await _clientsService.Add(ClientForm);
        return await _clientsService.Get(id);
    }

    private OrderModel BuildOrderModel(ClientModel client) => new()
    {
        Client = client,
        Products = NewCart!.Products!.ToList(),
        Amount = NewCart.TotalPrice,
        DateTime = DateTimeOffset.Now,
        Status = OrderStatus.Pending
    };

    private PaymentModel BuildPaymentModel(int orderId, int clientId) => new()
    {
        OrderId = orderId,
        ClientId = clientId,
        Method = SelectedPaymentMethod,
        Amount = (int)NewCart!.TotalPrice,
        Status = PaymentStatus.Pending,
        DateTime = DateTimeOffset.UtcNow,
        Details = $"Pago vía {PaymentMethods[SelectedPaymentMethod!].Label}",
    };

    #endregion

    #region Helpers 
    private bool IsFormValid() =>
        !string.IsNullOrWhiteSpace(ClientForm.Name) &&
        !string.IsNullOrWhiteSpace(ClientForm.Email) &&
        !string.IsNullOrWhiteSpace(ClientForm.IdentificationNumber) &&
        !string.IsNullOrWhiteSpace(SelectedPaymentMethod) &&
        NewCart?.Products?.Any() == true;
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");
    #endregion
}
