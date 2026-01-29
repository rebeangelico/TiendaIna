using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Client")]
public class Client : IEntity<int> {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }


   // public static Client FromModel(ProductInfoModel model) => model.Adapt<Client>();
}
