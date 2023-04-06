using Microsoft.EntityFrameworkCore;
using order.Model;

namespace order.Data;
public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
}
