using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public class BEProducto
    {

        public Int64 idproducto { get; set; }
        public string Nombre { get; set; }
        public Int64 idcategoria { get; set; }
        public int idestado { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string LineaProducto { get; set; }
        public string codigo { get; set; }
        public Int64 idfoto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime fechaproduccion { get; set; }
        public DateTime fechaexpiracion { get; set; }
        public bool Error { get; set; }
        public String Respuesta { get; set; }

    }
}
