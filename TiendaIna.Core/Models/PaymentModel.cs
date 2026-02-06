
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class PaymentModel {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public PaymentStatus? Estado { get; set; }
    public DateTimeOffset? DateTime { get; set; }
    public string? Details { get; set; }
    public int? Amount { get; set; }
    public int? ClientId { get; set; }

    public static PaymentModel FromEntity(Payment payment) => payment.Adapt<PaymentModel>();
}
