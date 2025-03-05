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
    }
}


//public IEnumerable<Cliente> GetClientesConPrestamos()
//{
//    var clientesConPrestamos = _context.Cliente.Include(u => u.Prestamo).ToList();
//    return clientesConPrestamos;
//}