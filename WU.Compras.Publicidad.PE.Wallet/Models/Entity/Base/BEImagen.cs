using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Entity.Base
{
    public class BEImagen
    {

        public Int64 idfoto { get; set; }
        public Guid hashCode { get; set; }
        public string Nombre { get; set; }
        public string rutafoto { get; set; }
        public bool idestado { get; set; }
        public int? posicionPortada { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string descripcion { get; set; }
         public Int64 IDFotoGrupo { get; set; }
        public Guid  IdusuarioCreacion { get; set; }
    }
}
