using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WU.Compras.Publicidad.PE.Wallet.Data
{
    public class Conecta
    {
        private readonly IConfiguration _Configuration;
        public Conecta()
        {
            var Config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _Configuration = Config.Build();
            //TimeOut = int.Parse(_Configuration["Data:TimeOut"]);
        }
        public IDbConnection GetConexion()
        {
            IDbConnection Coneta = new SqlConnection(_Configuration["ConnectionStrings:DefaultConnection"].ToString().Trim());
            Coneta.Open();
            return Coneta;

        }
        public string GetFilePath()
        {
            string Filepath = _Configuration["PathFilesPicture:PictureFile"].ToString().Trim();
            return Filepath;
        }
    }
}
