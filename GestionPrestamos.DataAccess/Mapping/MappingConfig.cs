using AutoMapper;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps() 
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Cliente, ClienteDto>().ReverseMap();
				config.CreateMap<Prestamo, PrestamoDto>().ReverseMap();
				config.CreateMap<Cuota, CuotaDto>().ReverseMap();
				config.CreateMap<Interes, InteresDto>().ReverseMap();
				config.CreateMap<Pagos, PagosDto>().ReverseMap();
			});
			return mappingConfig;
		}
	}
}
