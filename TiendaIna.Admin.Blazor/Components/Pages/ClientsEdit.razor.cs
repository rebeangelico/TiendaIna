using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using TiendaIna.Core;
using TiendaIna.Core.Extensions;
using TiendaIna.Core.Models;
using TiendaIna.Core.Services;

namespace TiendaIna.Admin.Blazor.Components.Pages;
public partial class ClientsEdit : ComponentBase {
    #region ReadOnly fields  (services)
    private readonly IClientsService _clientsService;
    private readonly NotificationService _notificationService;
    private readonly DialogService _dialogService;
    #endregion

    #region Constructors
    public ClientsEdit(IClientsService brandsService, NotificationService notificationService, DialogService dialogService) : base() {
        _clientsService = brandsService ?? throw new ArgumentNullException(nameof(brandsService));
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }
    #endregion

    #region Fields
    public List<ClientModel> _originalClients = [];
    #endregion

    #region Components
    public RadzenDataGrid<ClientModel?> Grid { get; set; }
    #endregion


    #region Properties

    public List<ClientModel> Clients { get; set; }
    public ClientModel? ClientToInsert { get; set; } = null;
    public ClientModel? ClientToUpdate { get; set; } = null;
    public bool IsLoading { get; set; } = false;
    #endregion


    #region Overriden Methods
    protected override async Task OnInitializedAsync() {
        await LoadData();
    }
    #endregion

    #region Private Methods
    private async Task LoadData() {
        try
        {
            IsLoading = true;
            _originalClients = await _clientsService.GetAll();
            Clients = _originalClients.DeepClone();
            StateHasChanged();
        }
        catch (Exception ex)
        {
            NotifyError("Error al cargar clientes", ex);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task InsertRow() {
        ClientToInsert = new ClientModel();
        await Grid.InsertRow(ClientToInsert);
    }

    private async Task DeleteRow(ClientModel client) {
        try
        {
            var result = await _dialogService.Confirm("¿Deseas eliminar este cliente?", "¿Estás seguro?",
                new ConfirmOptions() { OkButtonText = "Sí", CancelButtonText = "No" });

            if (result == true)
            {
                await _clientsService.Delete(client.Id);
                Clients.RemoveBy(b => b.Id == client.Id);
                await Grid.Reload();
                NotifySuccess("Cliente eliminado exitosamente");
            }
        }
        catch (Exception ex)
        {
            NotifyError("Error al Eliminar cliente", ex);
        }
    }

    private async Task EditRow(ClientModel client) {
        ClientToUpdate = client;
        await Grid.EditRow(ClientToUpdate);
    }

    private void CancelEdit(ClientModel client) {
        Clients?.RestoreFromList(c => c.Id == client.Id, _originalClients);
        Grid.CancelEditRow(client);
        Grid.Reload();
        Reset();
    }

    private async Task SaveRow(ClientModel client) {
        try
        {
            if (client.Id > 0)
            {
                await _clientsService.Update(client);
                NotifySuccess("Cliente actualizado exitosamente");
            }
            else
            {
                var id = await _clientsService.Add(client);
                client.Id = id;
                _originalClients.Add(client.DeepClone());
                Clients.Add(client);
                NotifySuccess("Cliente insertado exitosamente");
            }
            await Grid.UpdateRow(client);
            await Grid.Reload();
            Reset();
        }
        catch (Exception ex)
        {
            NotifyError("Error al actualizar Cliente", ex);
        }

    }

    void Reset() {
        ClientToInsert = null;
        ClientToUpdate = null;
    }
    #endregion

    #region Helpers
    private void NotifySuccess(string message) =>
        _notificationService.Notify(NotificationSeverity.Success, "Éxito", message);

    private void NotifyError(string context, Exception ex) =>
        _notificationService.Notify(NotificationSeverity.Error, "Error", $"{context}: {ex.Message}");

    #endregion
}
