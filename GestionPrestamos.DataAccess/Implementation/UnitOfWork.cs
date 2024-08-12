using AutoMapper;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.DataAccess.Implemetation;
using GestionPrestamos.Domain.Entities;
using GestionPrestamos.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly GestionPrestamosDbContext _context;
        private IMapper _mapper;

        public UnitOfWork(GestionPrestamosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            Cliente = new ClienteRepository(_context, mapper);
            Cuota = new CuotaRepository(_context, mapper);
            Prestamo = new PrestamoRepository(_context, mapper);
        }

        public IClienteRepository Cliente { get; private set; }

        public ICuotaRepository Cuota { get; private set; }

        public IInteresRepository Interes { get; private set;}

        public IPagosRepository Pagos { get; private set; }

        public IPrestamoRepository Prestamo { get; private set; }

		public int Save() 
        {
            return _context.SaveChanges();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
