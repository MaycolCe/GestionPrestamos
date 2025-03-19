using AutoMapper;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Entities;
using GestionPrestamos.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrestamos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoInteresClienteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrestamoInteresClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("PrestamoInteresCuota")]
        public ActionResult GetPrestamoInteresCuota()
        {
            var prestamo = _unitOfWork.Prestamo.GetPrestamoClienteCuota();
            var prestamoDto = _mapper.Map<List<PrestamoClienteCuotaDto>>(prestamo);
            return Ok(prestamoDto);
        }

        [HttpPost("CrearPrestamo")]
        //el dto trae los prestamos, arreglar
        public ActionResult<PrestamoClienteCuotaDto> CrearPrestamo([FromBody] PrestamoClienteCuotaDto prestamoClienteCuotaDto)
        {
            if (prestamoClienteCuotaDto == null)
            {
                return BadRequest("El cliente no puede ser nulo");
            }
            //var clienteCreado = _unitOfWork.Cliente.GetById(cliente.ClienteId);
            //var clienteCreadoDto = _mapper.Map<ClienteDto>(clienteCreado);
            var prestamoCliente = _mapper.Map<Prestamo>(prestamoClienteCuotaDto);

            //var nuevoPrestamoCliente = _unitOfWork.Prestamo.Add(prestamoCliente);
            _unitOfWork.Prestamo.Add(prestamoCliente);

            try
            {
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
            }

            var prestamoCreadoDto = _mapper.Map<PrestamoClienteCuotaDto>(prestamoCliente);
            return Ok(prestamoCreadoDto);
        }
    }
}


//public IEnumerable<Cliente> GetClientesConPrestamos()
//{
//    var clientesConPrestamos = _context.Cliente.Include(u => u.Prestamo).ToList();
//    return clientesConPrestamos;
//}