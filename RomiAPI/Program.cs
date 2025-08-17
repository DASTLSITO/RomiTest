using Microsoft.EntityFrameworkCore;
using RomiAPI;
using RomiCapaAplicacion.CasosDeUso;
using RomiCapaAplicacion.CasosDeUsoInterfaces;
using RomiCapaAplicacion.Interfaces;
using RomiCapaInfraestructura;
using RomiCapaInfraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);
var allowedHost = builder.Configuration.GetValue<string>("allowedHost")!;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration.WithOrigins(allowedHost).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IClienteCasos, ClienteCasos>();

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
