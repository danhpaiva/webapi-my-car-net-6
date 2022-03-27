using Microsoft.EntityFrameworkCore;
using MyCarApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration;
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer("Password=12345;Persist Security Info=True;User ID=sa;Initial Catalog=MyCar;Data Source=DESKTOP-IQUUNOA"));

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
