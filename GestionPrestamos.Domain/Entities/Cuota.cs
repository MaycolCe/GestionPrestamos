using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Entities
{
	public class Cuota
	{
		public int CuotaId { get; set; }

		public int PrestamoId { get; set; }

		public int CantidadCuotas { get; set; }

		public int CuotasPagadas { get; set; }

		public int CuotasRestantes { get; set; }

		public int PagosId { get; set; }

		public DateTime FechaPagoCuota { get; set; }

		public decimal ValorCuota { get; set; }
	}
}
