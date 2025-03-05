using GestionPrestamos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPrestamos.Domain.DTO
{
    public class PrestamoClienteCuotaDto
    {
        public int PrestamoId { get; set; }

        public int ClienteId { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public decimal CantidadPago { get; set; }

        public decimal Total { get; set; }

        public decimal? AbonoCapital { get; set; }

        public decimal TotalPrestamo { get; set; }

        public List<InteresDto>? Interes { get; set; }
        public List<CuotaDto>? Cuota { get; set; }
        public Cliente Cliente { get; set; }
    }
}
