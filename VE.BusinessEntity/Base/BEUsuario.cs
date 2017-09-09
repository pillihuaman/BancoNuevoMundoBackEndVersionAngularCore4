using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
   public class BEUsuario
    {

        public Int64 IdUsuario { get; set; }
        public Int64 IdCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public byte? ConfirmoMovil { get; set; }
        public byte? ConfirmoEmail { get; set; }
        public string CodigoConfirmacionMovil { get; set; }
        public string CodigoConfirmacionEmail { get; set; }
        public int NumeroFallas { get; set; }
        public int NumeroReenvioPin { get; set; }
        public int IdEstadoUsuario { get; set; }
        public DateTime? FechaUltimoLogin { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid? TokenUsuario { get; set; }
        public DateTime? FechaActivacion { get; set; }
    }
}
