using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace order.Data;
public class OrderIRepository : IOrderIRepository
{
    private readonly OrderContext _context;

    public OrderIRepository(OrderContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }


    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}
