using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
   public class BEOperadores
    {
         public int IdTipoOperador { get; set; }
        public string TipoOperador { get; set; }
        public Nullable<bool> EsActivo { get; set; }
    }
}
