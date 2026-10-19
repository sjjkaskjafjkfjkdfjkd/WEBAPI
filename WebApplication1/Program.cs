using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AplicationDbContext>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Funciona Correctamente");

app.Run();
