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
				config.CreateMap<Cliente, ClienteConPrestamoDto>();
				config.CreateMap<Cuota, ClientePrestamoCuotaDto>();
				config.CreateMap<Prestamo, PrestamoClienteCuotaDto>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Cliente.Nombre))
				.ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Cliente.Apellido))
				.ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Cliente.Correo))
				.ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Cliente.Telefono))
				.ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Cliente.Estado))
				.ForMember(dest => dest.InteresId, opt => opt.MapFrom(src => src.Interes.InteresId))
				.ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.Interes.Capital))
				.ForMember(dest => dest.PorcentajeInteres, opt => opt.MapFrom(src => src.Interes.PorcentajeInteres))
				.ForMember(dest => dest.InteresGenerado, opt => opt.MapFrom(src => src.Interes.InteresGenerado))
				.ForMember(dest => dest.InteresMora, opt => opt.MapFrom(src => src.Interes.InteresMora))
                .ForMember(dest => dest.CuotaId, opt => opt.MapFrom(src => src.Cuota.CuotaId))
                .ForMember(dest => dest.CantidadCuotas, opt => opt.MapFrom(src => src.Cuota.CantidadCuotas))
				.ForMember(dest => dest.CuotasPagadas, opt => opt.MapFrom(src => src.Cuota.CuotasPagadas))
				.ForMember(dest => dest.CuotasRestantes, opt => opt.MapFrom(src => src.Cuota.CuotasRestantes))
				.ForMember(dest => dest.FechaPagoCuota, opt => opt.MapFrom(src => src.Cuota.FechaPagoCuota))
				.ForMember(dest => dest.ValorCuota, opt => opt.MapFrom(src => src.Cuota.ValorCuota)).ReverseMap();
				config.CreateMap<PrestamoClienteCuotaDto, Prestamo>();
				//config.CreateMap<PrestamoClienteCuotaDto, Prestamo>();
            });
			return mappingConfig;
		}
	}
}
