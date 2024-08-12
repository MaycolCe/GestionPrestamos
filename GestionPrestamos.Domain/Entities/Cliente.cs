using GestionPrestamos.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Entities
{
	public class Cliente
	{
		public int ClienteId { get; set; }

		public string Nombre { get; set; } = string.Empty;

		public string Correo { get; set; } = string.Empty;

		public string Telefono { get; set; } = string.Empty;

		public bool Estado { get; set; }

		public string Apellido { get; set; } = string.Empty;

		public List<Prestamo>? Prestamo { get; set; }
	}
}
