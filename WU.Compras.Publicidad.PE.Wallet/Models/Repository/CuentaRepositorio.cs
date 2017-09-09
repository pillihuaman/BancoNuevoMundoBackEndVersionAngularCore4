using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessLogical;
using VE.DataAccess.SQL;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Repository
{
    public class CuentaRepositorio : ICuenta
    {
        public MPCuenta LoginTokenUser(string Conexion, string NumeroDocumento, string Contraseña)
        {
            return new BLCuenta().LoginTokenUser(Conexion, NumeroDocumento, Contraseña);
        }

        public MPCuenta Vericarlogin(string Numerodocumento, string Contrasenia, string conexions)
        {
           return new DACuenta().Vericarlogin(Numerodocumento, Contrasenia, conexions);
        }
    }
}
