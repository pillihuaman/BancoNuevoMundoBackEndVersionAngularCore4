using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Config;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Abstract
{
    public interface IEmailService
    {
        bool SendEmailASync(BEemail email, EmailConfig ec);


    }
}
