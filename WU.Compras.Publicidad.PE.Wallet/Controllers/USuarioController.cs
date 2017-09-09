using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WU.Compras.Publicidad.PE.Wallet.Config;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WU.Compras.Publicidad.PE.Wallet.Models.AccountViewModels;
using WU.Compras.Publicidad.PE.Wallet.Models;
using Microsoft.AspNetCore.Identity;

namespace WU.Compras.Publicidad.PE.Wallet.Controllers
{
    public class UsuarioController : Controller
    {


        private ICuenta _icuenta;
        private readonly ConnectionString _connectionString;

        public UsuarioController(ICuenta _icuenta , IOptions<ConnectionString>  _connectionString)
        {
            this._icuenta = _icuenta;
            this._connectionString = _connectionString.Value;
      
        }
        public IActionResult Cuenta()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Cuenta(string DNI, string password)
        {

            var ValidarCuenta = _icuenta.Vericarlogin(DNI, password, _connectionString.DefaultConnection);

            if (ValidarCuenta.Error != true)
            {
                //cuando entra aca
    
                HttpContext.Session.SetString("DNI", ValidarCuenta.BECliente.NumeroDocumento);
                HttpContext.Session.SetString("NombreUsuario", ValidarCuenta.BEUsuario.NombreUsuario);
                HttpContext.Session.SetString("TokenUsuario", ValidarCuenta.BEUsuario.TokenUsuario.ToString());
                //return RedirectToAction("Productos");
                return ViewComponent("Login");

            }
            else
            {
                ViewBag.mensaje = ValidarCuenta.Respuesta;
                return View();
            }

          
      



          
        }
        [AutoValidateAntiforgeryToken]
        public IActionResult Productos()
        {
            ViewBag.Mensaje= HttpContext.Session.GetString("DNI");
            ViewBag.TokenUsuario = HttpContext.Session.GetString("TokenUsuario");
            return View();


        }

    

 
        public IActionResult Tiendas()
        {
            ViewBag.Mensaje = HttpContext.Session.GetString("DNI");
            ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
            return View();


        }
    }
}