using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;

namespace WU.Compras.Publicidad.PE.Wallet.Controllers
{
    public class MailingController : Controller
    {
        private readonly IEmailService _mailService;

        public MailingController(IEmailService mailingReposito)
        {
            _mailService = mailingReposito;
        }
        public IActionResult Index()
        {
            var Email = new VE.BusinessEntity.Base.BEemail();
            //Email.FromAdress= _mailService.

            //_mailService.SendEmailASync(Email);


            return View();
        }
    }
}