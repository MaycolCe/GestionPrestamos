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
            // Verificar si el cliente existe
            var cliente = _unitOfWork.Cliente.Find(c => c.ClienteId == prestamoClienteCuotaDto.ClienteId).FirstOrDefault();
            if (cliente == null)
            {
                return BadRequest("El cliente no existe.");
            }

            var prestamoCliente = _mapper.Map<Prestamo>(prestamoClienteCuotaDto);
            prestamoCliente.Cliente = cliente;

            // Crear y agregar Interes
            var interes = new Interes
            {
                Capital = prestamoClienteCuotaDto.Capital,
                PorcentajeInteres = prestamoClienteCuotaDto.PorcentajeInteres,
                InteresGenerado = prestamoClienteCuotaDto.InteresGenerado,
                InteresMora = prestamoClienteCuotaDto.InteresMora
            };

            _unitOfWork.Interes.Add(interes);
            prestamoCliente.Interes = interes; // Asignar el interés al préstamo

            // Crear y agregar Cuota
            var cuota = new Cuota
            {
                CantidadCuotas = prestamoClienteCuotaDto.CantidadCuotas,
                CuotasPagadas = prestamoClienteCuotaDto.CuotasPagadas,
                CuotasRestantes = prestamoClienteCuotaDto.CuotasRestantes,
                FechaPagoCuota = prestamoClienteCuotaDto.FechaPagoCuota,
                ValorCuota = prestamoClienteCuotaDto.ValorCuota
            };
            _unitOfWork.Cuota.Add(cuota);
            prestamoCliente.Cuota = cuota; // Asignar la cuota al préstamo

            // Agregar el préstamo con sus relaciones
            _unitOfWork.Prestamo.Add(prestamoCliente);

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