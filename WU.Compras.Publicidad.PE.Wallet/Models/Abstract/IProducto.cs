using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Abstract
{
   public  interface IProducto
    {
        Queue<MPProducto> GetLisRutaProducto( int idFoto ,string Conexion,string RutaFotos);
        BEProducto ShowDetalleProducto(string Conexion, string key);
        Queue<BEPedido> ValidarPedido(Queue<BEPedido> lstBEPedido);
         Queue<BEPedido> ListaPedidoValidado(Queue<Guid> Codigoproducto);
    }
}
