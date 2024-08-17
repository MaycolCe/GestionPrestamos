using AutoMapper;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionPrestamos.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        // GET: api/<ClienteController>        
		[HttpGet("Prestamos")]
		public ActionResult GetWithPrestamo() 
		{
			//consulta directa a la entidad 
			//var clientes = _unitOfWork.Cliente.GetClientesConPrestamos();
			//return Ok(clientes);

			//consulta con automapper
			var clientes = _unitOfWork.Cliente.GetClientesConPrestamos();
			// Mapear la lista de clientes a una lista de ClienteDto
			var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);
			return Ok(clientesDto);
		}

		[HttpGet("Clientes")]
		public ActionResult Get()
		{
			var clientes = _unitOfWork.Cliente.GetAll();
			// Mapear la lista de clientes a una lista de ClienteDto
			var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);
			return Ok(clientesDto);
		}

		[HttpGet("prueba")]
		public ActionResult clientes()
		{
			var result = _mapper.Map<List<ClienteDto>>(_unitOfWork.Cliente.GetAll());
			

		}
	}
} 
