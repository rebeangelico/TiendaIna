using Mapster.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Payment")]
public class Payment : IEntity<int> {
    public int Id { get; set; }
    public PaymentStatus? Estado { get; set; }
    public string? Details { get; set; }
    public int? Amount { get; set; }
    public Client? Client { get; set; }


   // public static Clients FromModel(ProductInfoModel model) => model.Adapt<Clients>();
}
