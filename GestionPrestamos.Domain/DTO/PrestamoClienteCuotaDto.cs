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
        //public int PrestamoId { get; set; }

        //public int ClienteId { get; set; }

        //public DateTime FechaPrestamo { get; set; }

        //public DateTime FechaRegistro { get; set; }

        //public decimal CantidadPago { get; set; }

        //public decimal Total { get; set; }

        //public decimal? AbonoCapital { get; set; }

        //public decimal TotalPrestamo { get; set; }

        //public Interes Interes { get; set; }
        //public Cuota Cuota { get; set; }
        //public Cliente Cliente { get; set; }
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal CantidadPago { get; set; }
        public decimal Total { get; set; }
        public decimal AbonoCapital { get; set; }
        public decimal TotalPrestamo { get; set; }

        public int InteresId { get; set; }  // Solo el ID del interés

        public decimal Capital { get; set; }

        public decimal PorcentajeInteres { get; set; }

        public decimal InteresGenerado { get; set; }

        public decimal InteresMora { get; set; }
        public int CuotaId { get; set; }    // Solo el ID de la cuota

        public int CantidadCuotas { get; set; }

        public int CuotasPagadas { get; set; }

        public int CuotasRestantes { get; set; }

        public int PagosId { get; set; }

        public DateTime FechaPagoCuota { get; set; }

        public decimal ValorCuota { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public bool Estado { get; set; }

        public string Apellido { get; set; } = string.Empty;
    }
}
