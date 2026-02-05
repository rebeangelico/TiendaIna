using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Client")]
public class Client : IEntity<int> {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? IdentificationNumber { get; set; }
    //AGREGAR FECHA DE NACIMIENTO???
    //public Gender? Gender { get; set; } --- no creado en data base


    public static Client FromModel(ClientModel model) => model.Adapt<Client>();
}
