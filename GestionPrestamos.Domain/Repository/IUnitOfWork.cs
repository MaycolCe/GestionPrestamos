using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		IClienteRepository Cliente { get; }

		ICuotaRepository Cuota { get; }

		IInteresRepository Interes { get; }

		IPagosRepository Pagos { get; }

		IPrestamoRepository Prestamo { get; }

		int Save();
	}
}
