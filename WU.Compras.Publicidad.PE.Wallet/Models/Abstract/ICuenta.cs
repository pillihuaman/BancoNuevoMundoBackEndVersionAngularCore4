using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Abstract
{
   public interface ICuenta
    {
        MPCuenta Vericarlogin(string Numerodocumento, string Contrasenia,string conexions);
        MPCuenta LoginTokenUser(string Conexion, string NumeroDocumento, string Contraseña);
    }
}
