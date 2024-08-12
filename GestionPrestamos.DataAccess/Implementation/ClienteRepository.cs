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
	public class ClienteRepository : GenericoRepository<ClienteDto>, IClienteRepository
	{
		public ClienteRepository(GestionPrestamosDbContext context, IMapper mapper) : base(context, mapper) { }

		public IEnumerable<ClienteDto> GetClientesConPrestamos()
		{
			return _context.Cliente
				.ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
				.ToList();
		}

		public IEnumerable<ClienteDto> GetAllCliente()
		{
			return _context.Cliente
				.ProjectTo<ClienteDto>(_mapper.ConfigurationProvider, c => new {
					c.ClienteId,
					c.Nombre,
					Prestamo = c.Prestamo.Select(p => new PrestamoDto
					{
						PrestamoId = p.PrestamoId,
						CantidadPago = p.CantidadPago
						// Otros campos que quieras mapear
					})
				})
				.ToList();
		}
	}


}
