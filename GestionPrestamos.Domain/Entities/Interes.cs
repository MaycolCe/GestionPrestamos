using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Entities
{
	public class Interes
	{
		public int InteresId { get; set; }

		public int PrestamoId { get; set; }

		public decimal Capital { get; set; }

		public decimal PorcentajeInteres { get; set; }

		public decimal InteresGenerado { get; set; }

		public decimal InteresMora { get; set; }
	}
}
