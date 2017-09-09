using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;

namespace VE.BusinessEntity
{
    public class MPPedido
    {
        public BEPedido BEPedido { get; set; }
        public List<BEPedido> lstBEPedido { get; set; }

    }
}
