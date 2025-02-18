using AutoMapper;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.DataAccess.Implementation;
using GestionPrestamos.Domain;
using GestionPrestamos.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    //si se quiere activar las cors a ciertas rutas determinas debera ponerse en el controller  [EnableCors("AllowReactApp")]
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Dominio de tu aplicación React
              .AllowAnyHeader()                   // Permite cualquier encabezado
              .AllowAnyMethod();                  // Permite cualquier método (GET, POST, etc.)
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadir BD service
builder.Services.AddDbContext<GestionPrestamosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//,
	//b => b.MigrationsAssembly("GestionPrestamos.DataAccess")));
//Inyecto el automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMvc()
				.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Habilita CORS antes de mapear controladores
app.UseCors("AllowReactApp");

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
