public class OrderFactory
    {
        public static Order CreateOrder(int id, DateTime date, List<OrderItem> orderItems, ShippingAddress shippingAddress)
        {
            return new Order
            {
                Id = id,
                OrderDate = date,
                OrderItems = orderItems,
                ShippingAddress = shippingAddress
            };
        }
    }
