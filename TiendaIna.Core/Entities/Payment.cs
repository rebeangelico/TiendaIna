using Mapster.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaIna.Core.Models;

namespace TiendaIna.Core.Entities;

[Table("Payment")]
public class Payment : IEntity<int> {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? Method { get; set; }
    public PaymentStatus? Status { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public string? Details { get; set; }
    public int? Amount { get; set; }
    public int? ClientId { get; set; }

    public static Payment FromModel(PaymentModel model) => model.Adapt<Payment>();
}
