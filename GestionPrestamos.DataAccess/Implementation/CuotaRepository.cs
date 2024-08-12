using AutoMapper;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.Domain.Entities;
using GestionPrestamos.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Implementation
{
	public class CuotaRepository : GenericoRepository<Cuota>, ICuotaRepository 
	{
		public CuotaRepository(GestionPrestamosDbContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
