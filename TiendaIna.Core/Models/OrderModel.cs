
using TiendaIna.Core.Entities;

namespace TiendaIna.Core.Models;

public class OrderModel {
    public int Id { get; set; }
    public ClientModel? Client { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public ICollection<ProductInfoModel>? Products { get; set; }
    public decimal? Amount { get; set; }
    public ICollection<PaymentModel>? Payments { get; set; }
    public PaymentModel? LastPayment { get; set; }
    public OrderStatus Status { get; set; }

    public static OrderModel FromEntity(Order order) => order.Adapt<OrderModel>();

    public decimal CalculadorAmount(ICollection<ProductInfoModel> Products) { 
    decimal amount = 0;
    decimal price = 0;
        foreach (var product in Products) {
            price = product.Price*product.Quantity;
            amount = amount+price;
        }
        return amount;
    }

}
