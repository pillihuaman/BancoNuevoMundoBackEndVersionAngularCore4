using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
   public class BEPedido
    {

        public Int64 IdPedido { get; set; }
        public Guid Codigo { get; set; }
        public string Nombre { get; set; }
        public Int64 IdCliente { get; set; }
        public int IdTipoEnvio { get; set; }
        public int IdEstadoPedido { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIGV { get; set; }
        public int Cantidad { get; set; }
        public string IDusuario { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Comentario { get; set; }
        public Int64 IdCuentaTarjeta { get; set; }
        public DateTime FechaValidacion { get; set; }
         public int Stock { get; set; }
        public string  descripcion { get; set; }
        public DateTime fechaproduccion { get; set; }
        public DateTime fechaexpiracion { get; set; }
        public bool Error { get; set; }
        public string respuesta { get; set; }
      public string Token { get; set; }
    }
}
