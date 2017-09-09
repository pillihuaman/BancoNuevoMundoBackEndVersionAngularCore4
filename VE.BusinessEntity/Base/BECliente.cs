using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public class BECliente
    {
        public Int64 IdCliente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaEmisionDocumento { get; set; }
        public string Email { get; set; }
        public int IdTipoOperador { get; set; }
        public string NumeroMovil { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int IdEstadoCivil { get; set; }
        public byte? Genero { get; set; }
        public bool RecibeBoletin { get; set; }
        public bool AceptaPolitica { get; set; }
        public int IdCanalAfiliacion { get; set; }
        public bool RecibeTarjeta { get; set; }
        public Guid CodigoAfiliacion { get; set; }
        public int IdEstadoCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdPerfil { get; set; }
        public int? IdReferido { get; set; }
        public int? IdStand { get; set; }
        public string Usuario { get; set; }
        public int? IdTipoActivacion { get; set; }

    }
}
