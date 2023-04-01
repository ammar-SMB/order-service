# order microservice

Step by Step Instructions
Dotnet Core Microservice - Code First approach using EntityFramework in .NET 7.0
#EntityFramework #DotNet #CodeFirst #Repository #DesignPatterm #FactoryDesign #Microservice 

This is part one of the series.

We will use SQL Server db, repository pattern. We will also use the 12 factor app principles which are defined by Martin Fowler - https://12factor.net

Source Code: https://github.com/ammar-SMB/order-service

We will be build Order micro service.

dotnet cli for creating new web app: 
	dotnet new webapi -n order-service

We will use Code first methodology using Entity Framework with net 7
Include following packages from nuget
1) EntityFrameworkCore
2) EntityFrameworkCore.Design
3) EntityFrameworkCore.SqlServer

Model class
Order.cs

Data classes
Order Context
IOrderRepository (interface)
OrderRepository

connection string in json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Database=OrdersDB;Integrated Security=false;User ID=YYYY;Password=XXXX;Encrypt=true;TrustServerCertificate=true;"
  }
  
FactoryDesign Pattern:
OrderFactory

Program.cs file add the following code
	builder.Services.AddDbContext<OrderContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
	builder.Services.AddScoped<IOrderRepository, IOrderRepository>();

 To build model from the code run following cmds:
	dotnet ef migrations add InitialCreate
	dotnet ef database update
	
controller
	OrderController
	
Test using Swagger
