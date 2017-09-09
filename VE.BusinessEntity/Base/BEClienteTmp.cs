using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
   public  class BEClienteTmp
    {
        public Int64 IdClienteTmp { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaEmisionDocumento { get; set; }
        public string Email { get; set; }
        public int IdTipoOperador { get; set; }
        public string NumeroMovil { get; set; }
        public string IMEI { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int IdEstadoCivil { get; set; }
        public bool ? Genero { get; set; }
        public bool RecibeBoletin { get; set; }
        public bool AceptaPolitica { get; set; }
        public bool RecibeTarjeta { get; set; }
        public int IdCanalAfiliacion { get; set; }
        public int IdTipoEnvioTarjeta { get; set; }
        public int IdStand { get; set; }
        public string Ubigeo { get; set; }
        public int IdTipoCanalAfiliacion { get; set; }
        public int IdTipoDireccion { get; set; }
        public int IdPrefijoDireccion { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public string TelefonoFijo { get; set; }
        public string RangoDiasEntrega { get; set; }
        public string RangoHorasEntrega { get; set; }
        public bool ConfirmoMovil { get; set; }
        public bool ConfirmoEmail { get; set; }
        public string CodigoConfirmacionMovil { get; set; }
        public string CodigoConfirmacionEmail { get; set; }
        public int NumeroReenvioPin { get; set; }
        public string PasswordHash { get; set; }
        public int NumeroIntentosFallidos { get; set; }
        public int NumeroIntentosFallidosReenvio { get; set; }
        public Guid CodigoAfiliacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdReferido { get; set; }
        public string Usuario { get; set; }
        public int IdTipoActivacion { get; set; }
        public string IdDepartamento { set; get; }

        public string IdProvincia { set; get; }
        public string IdDistrito { set; get; }
 
    }
}
