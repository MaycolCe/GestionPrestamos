using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Context
{
	public class GestionPrestamosDbContext : DbContext
	{
		public GestionPrestamosDbContext(DbContextOptions<GestionPrestamosDbContext> options) : base(options) { }

		public DbSet<Cliente> Cliente { get; set; }

		public DbSet<Cuota> Cuota { get; set; }

		public DbSet<Interes> Interes { get; set; }

		public DbSet<Pagos> Pagos { get; set; }

		public DbSet<Prestamo> Prestamo { get; set; }

		
	}
}
