using AutoMapper;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.DataAccess.Implementation;
using GestionPrestamos.Domain;
using GestionPrestamos.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//A�adir BD service
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
