using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.Services
{
    public class UtilServices
    {

        public async Task<DateTime> GetCurrentTime()
        {
            var date = DateTime.Now;
            return await Task<DateTime>.FromResult(date);

        }
    }
}
