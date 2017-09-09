using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WU.Compras.Publicidad.PE.Wallet.Models;
using WU.Compras.Publicidad.PE.Wallet.Models.AccountViewModels;

namespace WU.Compras.Publicidad.PE.Wallet.Services
{
   public interface IUserService
    {
        ApplicationUser Autentificacion(string username, string passwoprd);
        IEnumerable<RegisterViewModel> GetAll();
        RegisterViewModel GetById(int id);
        RegisterViewModel Create(RegisterViewModel user, string password);
        void Update(RegisterViewModel user, string password=null);
        void Delete(int id);

    }
}
