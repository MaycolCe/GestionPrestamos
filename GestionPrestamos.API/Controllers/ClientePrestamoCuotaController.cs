using AutoMapper;
using GestionPrestamos.Domain.DTO;
using GestionPrestamos.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestionPrestamos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePrestamoCuotaController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientePrestamoCuotaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("ClienteCuota")]
        public ActionResult GetCuota()
        {
            var cuota = _unitOfWork.Cuota.GetClientesPrestamoCuota();
            var cuotaDto = _mapper.Map<List<ClientePrestamoCuotaDto>>(cuota);
            return Ok(cuotaDto);
        }
    }
}
