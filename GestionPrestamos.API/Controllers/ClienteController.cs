using AutoMapper;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Entities;
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
			//consulta con automapper
			var clientes = _unitOfWork.Cliente.GetClientesConPrestamos();
			// Mapear la lista de clientes a una lista de ClienteDto
			var clientesDto = _mapper.Map<List<ClienteConPrestamoDto>>(clientes);
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

		[HttpGet("ClienteId/{clienteId}")]
		public ActionResult GetCliente(int clienteId) 
		{
            var clienteExistente = _unitOfWork.Cliente.GetById(clienteId);

            if (clienteExistente == null)
            {
                return BadRequest("El cliente no puede ser nulo");
            }

            return Ok(clienteExistente);
        }

        [HttpGet("prueba")]
		public ActionResult clientes()
		{
			//consulta el automapper trae la lista de clientes y lista todos los clientes GETALL que es el metodo del repositorio generico
			var result = _mapper.Map<List<ClienteDto>>(_unitOfWork.Cliente.GetAll());
			return Ok(result);

		}

		[HttpPost("CrearCliente")]
		//el dto trae los prestamos, arreglar
		public ActionResult<ClienteDto> CreateCliente([FromBody] ClienteDto clienteDto) 
		{
			if (clienteDto == null) 
			{
				return BadRequest("El cliente no puede ser nulo");
			}
			var cliente = _mapper.Map<Cliente>(clienteDto);
            //var nuevoCliente = _unitOfWork.Cliente.Add(Cliente);
			_unitOfWork.Cliente.Add(cliente);

            _unitOfWork.Save();

            var clienteCreado = _unitOfWork.Cliente.GetById(cliente.ClienteId);
            var clienteCreadoDto = _mapper.Map<ClienteDto>(clienteCreado);
            //var clienteCreadoDto = _mapper.Map<ClienteDto>(nuevoCliente);

			return Ok(clienteCreadoDto);
		}

        [HttpPut("ActualizarCliente/{clienteId}")]
        public ActionResult ActualizarCliente(int clienteId, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("El cliente no puede ser nulo");
            }

            // Verificar si el cliente existe en la base de datos
            var clienteExistente = _unitOfWork.Cliente.GetById(clienteId);
            if (clienteExistente == null)
            {
                return NotFound($"El cliente con ID {clienteId} no fue encontrado.");
            }

            // Mapear los datos del DTO al cliente existente
            _mapper.Map(clienteDto, clienteExistente);

            // Actualizar el cliente en el repositorio
            _unitOfWork.Cliente.Update(clienteExistente);

            // Guardar los cambios
            _unitOfWork.Save();

            return NoContent(); // HTTP 204: Actualización exitosa, sin contenido
        }

    }
} 
