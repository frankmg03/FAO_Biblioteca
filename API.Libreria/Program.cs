using API.Core.Interfaces;
using API.Core.Servicios;
using API.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Configuracion.CadenaConexxion = builder.Configuration.GetConnectionString("CadenaConexion");

builder.Services.AddTransient<IAutores, AutoresServicio>();
builder.Services.AddTransient<IClientes, ClientesServicio>();
builder.Services.AddTransient<IGeneros, GenerosServicio>();
builder.Services.AddTransient<ILibros, LibrosServicio>();
builder.Services.AddTransient<IPrestamos, PrestamosServicio>();


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
