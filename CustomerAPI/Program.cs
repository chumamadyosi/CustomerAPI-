using CustomerAPI.Data;
using CustomerAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDbConext")));
builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
