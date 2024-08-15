using GestionPrestamos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.Repository
{
	public interface IClienteRepository : IGenericoRepository<Cliente>
	{
		IEnumerable<Cliente> GetClientesConPrestamos();
	}
}
