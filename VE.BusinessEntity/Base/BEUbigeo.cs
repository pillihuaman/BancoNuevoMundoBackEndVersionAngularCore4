using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public  class BEUbigeo
    {
        public string Ubigeo { set; get; }
        public string IdDepartamento { set; get; }

        public string IdProvincia { set; get; }
        public string IdDistrito { set; get; }
         public string Departamento { set; get; }
        public string Provincia { get; set; }
         public string Distrito { get; set; }
         public byte Activo { get; set; }

    }
}
