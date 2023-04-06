using System.ComponentModel.DataAnnotations;
namespace order.Model;

public class Order
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public List<OrderItem> OrderItems { get; set; }
    [Required]
    public ShippingAddress ShippingAddress { get; set; }
}
public class ShippingAddress
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Zipcode { get; set; }
    [Required]
    public int OrderId { get; set; }
}
public class OrderItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int OrderId { get; set; }
}
