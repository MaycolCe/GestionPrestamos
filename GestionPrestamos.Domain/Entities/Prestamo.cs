using GestionPrestamos.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Entities
{
	public class Prestamo
	{
		public int PrestamoId { get; set; }

		public int ClienteId { get; set; }

		public DateTime FechaPrestamo { get; set; }

		public DateTime FechaRegistro { get; set; }

		public decimal CantidadPago { get; set; }

		public decimal Total { get; set; }

		public decimal? AbonoCapital { get; set; }

		public decimal TotalPrestamo { get; set; }

		//public Cliente Cliente { get; set; }
		[NotMapped]
		public ClienteDto Cliente { get; set; }
	}
}
