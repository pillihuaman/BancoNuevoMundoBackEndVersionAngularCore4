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
    public class BLCuenta
    {
        public MPCuenta Vericarlogin(string numerodocumento,string contraseña,string conexion)
        {
            return  new DACuenta().Vericarlogin(numerodocumento, contraseña, conexion);
            //return new AfiliacionDA().AgregarCliente(codigoAfiliacion);
        }

        public MPCuenta LoginTokenUser(string Conexion, string NumeroDocumento, string Contraseña)
        {
            return new DACuenta().LoginTokenUser(Conexion, NumeroDocumento, Contraseña);
            //return new AfiliacionDA().AgregarCliente(codigoAfiliacion);
        }


    }
}
