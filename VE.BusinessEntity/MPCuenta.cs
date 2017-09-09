using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using System.Collections;

namespace VE.BusinessEntity
{
    public class MPCuenta
    {
        public BECliente BECliente { get; set; }
        public BEClienteTmp BEClienteTmp { get; set; }
        public BEUsuario BEUsuario { get; set; }
        public bool Error { get; set; }
        public string Respuesta { get; set; }
        public string Mensaje { get; set; }








    }
}
