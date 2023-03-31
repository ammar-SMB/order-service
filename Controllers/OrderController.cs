using Microsoft.AspNetCore.Mvc;
using order.Data;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderRepository.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    [HttpPost]
    public async Task<IActionResult> Post(Order order)
    {
        await _orderRepository.AddOrderAsync(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        await _orderRepository.UpdateOrderAsync(order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderRepository.DeleteOrderAsync(id);
        return NoContent();
    }
    
}