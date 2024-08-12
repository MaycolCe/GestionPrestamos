using AutoMapper;
using AutoMapper.QueryableExtensions;
using GestionPrestamos.DataAccess.Context;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.DataAccess.Implementation
{
	public class GenericoRepository<T> : IGenericoRepository<T> where T : class
	{
		public readonly GestionPrestamosDbContext _context;
		public IMapper _mapper;

		public GenericoRepository(GestionPrestamosDbContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
		}


		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AddRange(entities);
		}

		public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
		{
			return _context.Set<T>().Where(predicate);
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}
	}
}
