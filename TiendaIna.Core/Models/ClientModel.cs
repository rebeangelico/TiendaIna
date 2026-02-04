
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class ClientModel {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? IdentificationNumber { get; set; }
    // public Gender? Gender { get; set; }

    public static ClientModel FromEntity(Client client) => client.Adapt<ClientModel>();

}
