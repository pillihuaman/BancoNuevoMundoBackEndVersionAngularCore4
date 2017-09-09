using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;

namespace VE.BusinessEntity
{
   public class MPProducto
    {
         public BEFotos BEFoto { get; set; }
        public BEProducto Producto { get; set; }
        public bool Error { get; set; }
        public string Respuesta { get; set; }
    }
}
