using Moq;
using NUnit.Framework;

namespace order.Data;
[TestFixture]
public class MockOrderRepositoryTests
{
    private Mock<IOrderRepository> _mockOrderRepository;

    [SetUp]
    public void Setup()
    {
        _mockOrderRepository = new Mock<IOrderRepository>();
    }

    [Test]
    public async Task Test_CreateOrders()
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        orderItems.Add(new OrderItem { Id = 1, ProductId = 1, Quantity = 2, OrderId = 1 });
        orderItems.Add(new OrderItem { Id = 2, ProductId = 2, Quantity = 3, OrderId = 1 });

        List<OrderItem> orderItems2 = new List<OrderItem>();
        orderItems2.Add(new OrderItem { Id = 3, ProductId = 1, Quantity = 1, OrderId = 2 });
        orderItems2.Add(new OrderItem { Id = 4, ProductId = 3, Quantity = 4, OrderId = 2 });

        List<ShippingAddress> addresses = new List<ShippingAddress>(){
            new ShippingAddress { Id=1, AddressLine1="345 Main street", City="Irvine", State="CA", Zipcode="89756", OrderId=1},
            new ShippingAddress { Id=2, AddressLine1="7331 Marigold lane", City="Prescott", State="AZ", Zipcode="08872", OrderId=2},
        };

        List<Order> orders = new List<Order>();
        orders.Add(OrderFactory.CreateOrder(1, DateTime.Now.AddDays(-30),
                        orderItems, addresses[0]));
        orders.Add(OrderFactory.CreateOrder(2, DateTime.Now.AddDays(-25),
                        orderItems2, addresses[1]));

        Assert.AreEqual(2, orders.Count);
    }

    // [Test]
    // public async Task Test_GetEmployeeById()
    // {
    //     // Arrange
    //     int id = 1;
    //     Employee employee = new Employee { Id = id, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" };
    //     _mockEmployeeRepository.Setup(r => r.GetById(id)).ReturnsAsync(employee);

    //     // Act
    //     Employee result = await _employeeService.GetEmployeeById(id);

    //     // Assert
    //     Assert.IsNotNull(result);
    //     Assert.AreEqual(id, result.Id);
    //     Assert.AreEqual("John", result.FirstName);
    //     Assert.AreEqual("Doe", result.LastName);
    //     Assert.AreEqual("johndoe@example.com", result.Email);
    //     _mockEmployeeRepository.Verify(r => r.GetById(id), Times.Once);
    // }

    // [Test]
    // public async Task Test_GetAllEmployees()
    // {
    //     // Arrange
    //     List<Employee> employees = new List<Employee>
    //     {
    //         new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" },
    //         new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com" },
    //         new Employee { Id = 3, FirstName = "Bob", LastName = "Johnson", Email = "bobjohnson@example.com" }
    //     };
    //     _mockEmployeeRepository.Setup(r => r.GetAll()).ReturnsAsync(employees);

    //     // Act
    //     List<Employee> result = await _employeeService.GetAllEmployees();

    //     // Assert
    //     Assert.IsNotNull(result);
    //     Assert.AreEqual(3, result.Count);
    //     Assert.AreEqual("John", result[0].FirstName);
    //     Assert.AreEqual("Smith", result[1].LastName);
    //     Assert.AreEqual("bobjohnson@example.com", result[2].Email);
    //     _mockEmployeeRepository.Verify(r => r.GetAll(), Times.Once);
    // }

    // Add more tests for the other methods in EmployeeService
}
