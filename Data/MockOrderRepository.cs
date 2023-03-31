namespace order.Data;
public class MockOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders;

    public MockOrderRepository()
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        orderItems.Add(new OrderItem { Id =1, ProductId = 1, Quantity = 2, OrderId = 1 });
        orderItems.Add(new OrderItem { Id =2, ProductId = 2, Quantity = 3, OrderId = 1 });

        List<OrderItem> orderItems2 = new List<OrderItem>();
        orderItems2.Add(new OrderItem { Id =3, ProductId = 1, Quantity = 1, OrderId = 2 });
        orderItems2.Add(new OrderItem { Id =4, ProductId = 3, Quantity = 4, OrderId = 2 });

        List<ShippingAddress> addresses = new List<ShippingAddress>(){
            new ShippingAddress { Id=1, AddressLine1="345 Main street", City="Irvine", State="CA", Zipcode="89756", OrderId=1},
            new ShippingAddress { Id=2, AddressLine1="7331 Marigold lane", City="Prescott", State="AZ", Zipcode="08872", OrderId=2},
        };

        _orders = new List<Order>();
        _orders.Add(OrderFactory.CreateOrder(1, DateTime.Now.AddDays(-30), 
                        orderItems, addresses[0] ));
        _orders.Add(OrderFactory.CreateOrder(2, DateTime.Now.AddDays(-25),
                        orderItems2, addresses[1]));
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await Task.FromResult(_orders);
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await Task.FromResult(_orders.FirstOrDefault(p => p.Id == id));
    }

    public async Task AddOrderAsync(Order order)
    {
        order.Id = _orders.Max(p => p.Id) + 1;
        _orders.Add(order);
        await Task.CompletedTask;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        var index = _orders.FindIndex(p => p.Id == order.Id);
        _orders[index] = order;
        await Task.CompletedTask;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = _orders.FirstOrDefault(p => p.Id == id);
        _orders.Remove(order);
        await Task.CompletedTask;
    }
}
