using Microsoft.EntityFrameworkCore;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseBlazorFrameworkFiles(); // Serve os arquivos do framework Blazor
app.UseStaticFiles(); // Serve arquivos estáticos (wwwroot)
app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS
app.UseAuthorization(); // Habilita a autorização

app.MapControllers(); // Mapeia os controllers

app.MapFallbackToFile("index.html"); // Fallback para o arquivo index.html (Blazor WebAssembly)

app.Run();
