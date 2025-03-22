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

        //public IEnumerable<Prestamo> GetPrestamoClienteCuota()
        //{
        //    var clientesPrestamosCuota = _context.Prestamo.Include(u => u.Cliente)
        //  .Include(u => u.Interes)
        //  .Include(u => u.Cuota)
        // //.Where(u => u.Cuota.Any())
        // .ToList();

        //    return clientesPrestamosCuota;
        //}

        public IEnumerable<Prestamo> GetPrestamoClienteCuota()
        {
            var clientesPrestamosCuota = from p in _context.Prestamo
                                         join c in _context.Cliente on p.ClienteId equals c.ClienteId
                                         join cu in _context.Cuota on p.PrestamoId equals cu.PrestamoId
                                         join i in _context.Interes on cu.PrestamoId equals i.PrestamoId
                                         select p;  // Retorna solo Prestamo

            foreach (var item in clientesPrestamosCuota)
            {
                var prestamo = _context.Prestamo
                 .Include(p => p.Cliente)  
                 .Include(p => p.Cuota)    
                 .Include(p => p.Interes)  
                 .FirstOrDefault(p => p.PrestamoId == item.PrestamoId);
            }

            return clientesPrestamosCuota.ToList(); // Convierte en lista para materializar la consulta
        }

    }
}


//var clientesConPrestamos = _context.Cliente.Include(u => u.Prestamo).ToList();
//return clientesConPrestamos;
