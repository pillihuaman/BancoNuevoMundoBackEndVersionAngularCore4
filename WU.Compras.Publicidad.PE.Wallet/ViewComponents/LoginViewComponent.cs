using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using WU.Compras.Publicidad.PE.Wallet.Config;
using WU.Compras.Publicidad.PE.Wallet.Models;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;

namespace WU.Compras.Publicidad.PE.Wallet.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly ICuenta _ICuenta;
        private readonly ConnectionString _connectionString;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        public LoginViewComponent( IOptions<ConnectionString> _connectionString , ICuenta _ICuenta, SignInManager<ApplicationUser> _SignInManager, UserManager<ApplicationUser> _UserManager)
        {
            this._ICuenta = _ICuenta;
            this._connectionString = _connectionString.Value;
            this._SignInManager = _SignInManager;
            this._UserManager = _UserManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (_SignInManager.IsSignedIn(HttpContext.User))
            {
                var user = await _UserManager.GetUserAsync(HttpContext.User);
                return View("LoggedIn", user);
            }
            else { return View(); }

        }
        //public async Task<MPCuenta> GetUsuarioToken()
        //{
        //    var Login = _ICuenta.LoginTokenUser(_connectionString.DefaultConnection, "46178209", "123456Ab.");
        //    return await Task.FromResult(Login);
        //}


    }
}
