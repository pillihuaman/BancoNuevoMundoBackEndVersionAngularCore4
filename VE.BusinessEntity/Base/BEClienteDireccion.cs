using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
   public  class BEClienteDireccion
    {
        public string gUsuario { get; set; }
        public int iDireccion { get; set; }
        public string xUbigeo { get; set; }
        public int iTipoDireccion { get; set; }
        public int iPrefijoDireccion { get; set; }

        public string xDireccion { get; set; }

        public string xReferencia { get; set; }
        public string xTelefonoFijo { get; set; }

        public int lPrincipal { get; set; }

        public int lActivo { get; set; }

        public DateTime dCreado { get; set; }

        public DateTime dModificado { get; set; }
    }
}
