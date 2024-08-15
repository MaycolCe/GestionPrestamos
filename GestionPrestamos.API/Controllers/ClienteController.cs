using AutoMapper;
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

		public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
		}

        // GET: api/<ClienteController>        
		[HttpGet("Prestamos")]
		public ActionResult GetWithPrestamo() 
		{
			var clientes = _unitOfWork.Cliente.GetClientesConPrestamos();
			return Ok(clientes);
		}

		[HttpGet("Clientes")]
		public ActionResult Get()
		{
			var clientes = _unitOfWork.Cliente.GetAll();
			return Ok(clientes);
		}
	}
} 
