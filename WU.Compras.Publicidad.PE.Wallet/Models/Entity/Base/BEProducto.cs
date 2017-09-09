using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Entity.Base
{
    public class BEProducto
    {

        public Int64 idproducto { get; set; }
        public string Nombre { get; set; }
        public int idcategoria { get; set; }
        public int idestado { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int LineaProducto { get; set; }
        public string codigo { get; set; }
        public decimal Precio { get; set; }
        public Int64 Iddetalleproducto { get; set; }
        public int Stock { get; set; }
        public DateTime fechaproduccion { get; set; }
        public DateTime fechaexpiracion { get; set; }
    }
}
