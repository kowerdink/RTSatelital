using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Infrastructure.Persistence;
using BackendRemis.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IChoferRepository, ChoferRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminAsignadoRepository, AdminAsignadoRepository>();
builder.Services.AddScoped<IOperadorRepository, OperadorRepository>();
builder.Services.AddScoped<IDuenioAutoRepository, DuenioAutoRepository>();

builder.Services.AddScoped<IViajeRepository, ViajeRepository>();
builder.Services.AddScoped<IAutoRepository, AutoRepository>();
builder.Services.AddScoped<IAutoChoferRepository, AutoChoferRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<ICuentaCorrienteRepository, CuentaCorrienteRepository>();
builder.Services.AddScoped<IAgendamientoRecurrenteRepository, AgendamientoRecurrenteRepository>();
builder.Services.AddScoped<IPermisoOperadorRepository, PermisoOperadorRepository>();
builder.Services.AddScoped<IRegistroDeSesionRepository, RegistroDeSesionRepository>();
builder.Services.AddScoped<ICodigoDireccionFrecuenteRepository, CodigoDireccionFrecuenteRepository>();
builder.Services.AddScoped<ITelefonoExtraRepository, TelefonoExtraRepository>();
builder.Services.AddScoped<IDireccionExtraRepository, DireccionExtraRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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

