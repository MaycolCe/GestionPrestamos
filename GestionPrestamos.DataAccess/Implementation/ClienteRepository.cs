using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.DataAccess.Implementation;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Entities;
using GestionPrestamos.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Implemetation
{
    public class ClienteRepository : GenericoRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GestionPrestamosDbContext context) : base(context) { }

        public IEnumerable<Cliente> GetClientesConPrestamos()
        {
            var clientesConPrestamos = _context.Cliente.Include(u => u.Prestamo).ToList();
            return clientesConPrestamos;
        }

        public IList<Cliente> PruebaClientes()
        {

            var clientesConPrestamos = _context.Cliente
            .Select(cliente => new Cliente
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Prestamo = _context.Prestamo
                    .Where(presta => presta.ClienteId == cliente.ClienteId)
                    .ToList()
            });

            return clientesConPrestamos.ToList();
        }

    }

}
