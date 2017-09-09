using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.Extenders
{
    public static class Util
    {

        //public static Task<string> Encryptersha1(string KeyEncryp)
        //{


        //}

        //public static Task<string> DesEncryptersha1(string KeyEncryp)
        //{


        //}
        public async static Task<string> EncryptToBase64String(string KeyEncryp)
        {
            string Salida = string.Empty;
            byte[] CollEncry = System.Text.Encoding.Unicode.GetBytes(KeyEncryp);
            Salida = Convert.ToBase64String(CollEncry);
            return await Task.FromResult<string>(Salida);
        }

        public async static Task<string> DescEncryptToBase64String(string KeyEncryp)
        {
            string Salida = string.Empty;
            byte[] CollEncry = Convert.FromBase64String(KeyEncryp);
            Salida = System.Text.Encoding.Unicode.GetString(CollEncry);
            return await Task.FromResult<string>(Salida);
        }




    }
}
