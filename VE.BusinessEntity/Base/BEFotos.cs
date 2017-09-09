using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public class BEFotos
    {

        public Int64 idfoto { get; set; }
        public string hashCode { get; set; }
        public string Nombre { get; set; }
        public string rutafoto { get; set; }
        public byte idestado { get; set; }
        public int posicionPortada { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    
    }
}
