using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Abstract
{
    public interface IAfilicion
    {
        //MPDatos Lista_Operador();
        MPDatos Lista_Operador(string Conexion);
        MPDatos ListaDepartamento(string Conexion);
        MPDatos Lista_Provincia(string conexion , string iddepartamento);
        MPDatos Lista_Distrito(string conxion, string iddepartamento, string idDistrito);
        BEParametro AfiliarClienteTemp(BEClienteTmp datosAfilia, string Conecta);
        MPDatos VericarCliente(Int32 IdClienteTmp, string Conexion);

        MPDatos ValidarCodigoAfiliacion(string Codigoafiliacion, string Conexion);

        //MPDatos InsertUsuarioEntity(string email, string contraseña);
    }
}
