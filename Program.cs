using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.OpenApi.Models;
using order.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddDbContext<OrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
    builder.Services.AddScoped<IOrderRepository, OrderIRepository>();
}
else
{
    builder.Services.AddScoped<IOrderRepository, MockOrderRepository>();
}

builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient",
                  builder =>
                  {
                      builder
                      .AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = ""; // this sets the Swagger UI as the root page
});
}

app.UseCors("AllowAngularClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



// if (app.Environment.IsDevelopment())
// {
//     builder.Services.AddScoped<IOrderRepository, MockOrderRepository>();
// }

