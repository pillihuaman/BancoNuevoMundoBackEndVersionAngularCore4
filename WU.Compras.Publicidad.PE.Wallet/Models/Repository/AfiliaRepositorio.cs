using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using VE.BusinessLogical;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Repository
{
    public class AfiliaRepositorio : IAfilicion
    {
        public BEParametro AfiliarClienteTemp(BEClienteTmp datosAfilia , string conecta)
        {
            return new BLAfilia().insertar_clienteTemp(datosAfilia,conecta);
        }



        //public MPDatos AfiliarClienteTemp(AfiliarClienteViewModel datosAfilia)
        //{
        //    //return new BLAfilia().insertar_clienteTemp(datosAfilia);
        //}

        public MPDatos ListaDepartamento(string Conexion)
        {
            return new BLAfilia().ListaDepartamento(Conexion);
        }

        public MPDatos Lista_Distrito(string conxion, string iddepartamento, string idDistrito)
        {
            return new BLAfilia().Lista_Distrito(conxion, iddepartamento, idDistrito);
        }

        //public MPDatos Lista_Operador()
        //{
        //    return new BLAfilia().Lista_Operador();
        //}
        public MPDatos Lista_Operador(string Conexion)
        {
            return new BLAfilia().Lista_Operador(Conexion);
        }


        public MPDatos Lista_Provincia(string Conexion, string Iddepartamento)
        {
            return new BLAfilia().Lista_Provincia(Conexion  , Iddepartamento);

        }

        public MPDatos ValidarCodigoAfiliacion(string Codigoafiliacion, string Conexion)
        {
            return new BLAfilia().ValidarCodigoAfiliacion(Codigoafiliacion, Conexion);
        }

        public MPDatos VericarCliente(int IdClienteTmp, string Conexion)
        {
            return new BLAfilia().VericarCliente(IdClienteTmp, Conexion);
        }
    
        //public BEClienteTmp VericarCliente(int IdClienteTmp,string Conexion)
        //{
        //    return new BLAfilia().VericarCliente(IdClienteTmp , Conexion);
        //}
    }
}
