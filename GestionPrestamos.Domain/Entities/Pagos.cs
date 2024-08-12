using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Entities
{
	public class Pagos
	{
		public int PagosId { get; set; }

		public int NumeroPago { get; set; }

		public int ClienteId { get; set; }
	}
}
