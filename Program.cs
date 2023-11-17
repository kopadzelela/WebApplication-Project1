using Microsoft.EntityFrameworkCore;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;
using WebApplication_Project1.Repositories.Repositories;
using WebApplication_Project1.BusinessLogic.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Connection To Database
var connectionString = builder.Configuration.GetConnectionString("ProjectDBEntities");
builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: S => S.EnableRetryOnFailure()));
builder.Services.AddScoped<DbContext, ProjectDBContext>();
#endregion

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomersRelationshipRepository, CustomersRelationshipRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
