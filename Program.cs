using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using usermgmt.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserMgmtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<UserMgmtRepository, UserMgmtRepository>();
builder.Services.AddScoped<IUserMgmtRepository, MockUserMgmtRepository>();

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
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


  
// if (app.Environment.IsDevelopment())
// {
//     builder.Services.AddScoped<UserMgmtRepository, UserMgmtRepository>();
// }

