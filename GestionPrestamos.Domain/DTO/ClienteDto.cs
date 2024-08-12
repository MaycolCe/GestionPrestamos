using GestionPrestamos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.DTO
{
	public class ClienteDto
	{
		public int ClienteId { get; set; }

		public string Nombre { get; set; } = string.Empty;

		public string Correo { get; set; } = string.Empty;

		public string Telefono { get; set; } = string.Empty;

		public bool Estado { get; set; }

		public string Apellido { get; set; } = string.Empty;

		public List<PrestamoDto>? Prestamo { get; set; }
	}
}
