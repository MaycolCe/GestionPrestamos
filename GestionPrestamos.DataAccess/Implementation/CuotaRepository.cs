using AutoMapper;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.Domain.Entities;
using GestionPrestamos.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Implementation
{
	public class CuotaRepository : GenericoRepository<Cuota>, ICuotaRepository 
	{
		public CuotaRepository(GestionPrestamosDbContext context) : base(context){ }

        public IEnumerable<Cuota> GetClientesPrestamoCuota()
        {
            var clientesPrestamosCuota = _context.Cuota
                .Include(c => c.Prestamo)
                .ThenInclude(p => p.Cliente)
                .ToList();

            return clientesPrestamosCuota;
        }
    }
}
