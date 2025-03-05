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
	public class PrestamoRepository : GenericoRepository<Prestamo>, IPrestamoRepository
	{
		public PrestamoRepository(GestionPrestamosDbContext context) : base(context)
		{
		}

		public IEnumerable<Prestamo> GetPrestamoClienteCuota() 
		{
            var clientesPrestamosCuota = _context.Prestamo.Include(u => u.Cliente)
				.Include(u => u.Interes)
				.Include(u => u.Cuota)
      //         .Include(c => c.Interes)
			   //.Include(c => c.Cuota)			   
			   //.Include(c => c.Cliente) no esta retornando
               .ToList();

            return clientesPrestamosCuota;
        }

    }
}


//var clientesConPrestamos = _context.Cliente.Include(u => u.Prestamo).ToList();
//return clientesConPrestamos;
