using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Models;
using WU.Compras.Publicidad.PE.Wallet.Models.AccountViewModels;

namespace WU.Compras.Publicidad.PE.Wallet.Services
{
   public interface IUserService
    {
        ApplicationUser Autentificacion(string username, string passwoprd);
        BEUsuario RegistrarUsuario(BEUsuario BEUsuario);
        IEnumerable<RegisterViewModel> GetAll();
        RegisterViewModel GetById(int id);
        BEUsuario Create(BEUsuario Beusuario);
        void Update(RegisterViewModel user, string password=null);
        void Delete(int id);

    }
}
