using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WU.Compras.Publicidad.PE.Wallet.Data;
using WU.Compras.Publicidad.PE.Wallet.Models;
using WU.Compras.Publicidad.PE.Wallet.Models.AccountViewModels;

namespace WU.Compras.Publicidad.PE.Wallet.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _Context;
        public UserService(ApplicationDbContext _Context)
        {
            this._Context = _Context;
        }
        public ApplicationUser Autentificacion(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var user = _Context.Users.SingleOrDefault(x => x.UserName == username);
          
            if (user == null)
                return null;
            if (!verificarPassHash(password, user.PasswordHash,user.PasswordSalt))
                return null;
             return user;
        }

        private bool verificarPassHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            if (password == null) throw new Exception("Password");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Contraseña en blanco only cadena", "Password");
            if (PasswordHash.Length != 64) throw new ArgumentException("Password no tiene la cantidad de(64) Bityes requeridos", "PassHash");
            if (PasswordSalt.Length != 128) throw new ArgumentException("Invalido tamalño de 128 bytes", "passSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt)) 
            {
                var Procesohash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i< Procesohash.Length; i++)
                {
                    if (Procesohash[i] != PasswordHash[i]) return false;

                }

            }
            return true;
        }

        public RegisterViewModel Create(RegisterViewModel user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisterViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RegisterViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RegisterViewModel user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
