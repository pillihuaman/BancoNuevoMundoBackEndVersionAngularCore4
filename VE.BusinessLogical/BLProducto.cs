using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using VE.DataAccess.SQL;

namespace VE.BusinessLogical
{
  public  class BLProducto
    {
      
        public Queue<MPProducto> GetLisRutaProducto(int idFoto, string conexion, string rutaFotos)
        {
            return new DAProducto().GetLisRutaProducto(idFoto, conexion, rutaFotos);
        }
        public BEProducto ShowDetalleProducto(string conexion,string key)
        {
            return new DAProducto().ShowDetalleProducto(conexion, key);
        }
    }
}
