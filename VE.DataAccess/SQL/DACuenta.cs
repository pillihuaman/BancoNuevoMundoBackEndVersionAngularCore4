using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using System.Data;
using System.Data.SqlClient;

namespace VE.DataAccess.SQL
{
    public class DACuenta
    {




        
        public MPCuenta Vericarlogin(string numerodocumento,string contraseña, string conexion)
        {

            bool error = false;
            string respuesta = "";
      
            //var BECliente = new BECliente();
            var DNI = string.Empty;
            var BEUsuario = new BEUsuario();
            try
            {

                var Parameter = new SqlParameter[4];
                Parameter[0] = new SqlParameter("@NumeroDocumento", SqlDbType.VarChar,8) { Value = numerodocumento };
                Parameter[1] = new SqlParameter("@Contrasenia", SqlDbType.VarChar, 20) { Value = contraseña};
                Parameter[2] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[3] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "dbo.login", Parameter))
                {
                    read.Read();
                    if (read.HasRows && !read.IsDBNull(read.GetOrdinal("idusuario")))
                    {

                       
                        BEUsuario.IdUsuario = read.GetInt64(read.GetOrdinal("idusuario"));
                        BEUsuario.NombreUsuario = read.GetString(read.GetOrdinal("NombreUsuario"));
                        DNI = read.GetString(read.GetOrdinal("NumeroDocumento"));
                        BEUsuario.TokenUsuario = read.GetGuid(read.GetOrdinal("TokenUsuario"));
                        error = read.GetBoolean(read.GetOrdinal("Error"));
                        respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }
                    else
                    {

                        //read.NextResult();
                        error = read.GetBoolean(read.GetOrdinal("Error"));
                        respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }
                }



            }

            catch (Exception ex)
            {
                throw ex;
            }

            return new MPCuenta { BEUsuario = BEUsuario,BECliente =  new BECliente() { NumeroDocumento=DNI}, Error = error, Respuesta = respuesta};

        }
        public MPCuenta LoginTokenUser(string Conexion, string NumeroDocumento, string Contraseña)
        {

            bool error = false;
            string respuesta = "";
            var BEUsuario = new BEUsuario();
            //var BECliente = new BECliente();
            var DNI = string.Empty;

            try
            {

                var Parameter = new SqlParameter[4];
                Parameter[0] = new SqlParameter("@NumeroDocumento", SqlDbType.VarChar, 8) { Value = NumeroDocumento };
                Parameter[1] = new SqlParameter("@Contrasenia", SqlDbType.VarChar, 20) { Value = Contraseña };
                Parameter[2] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[3] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(Conexion, CommandType.StoredProcedure, "dbo.login", Parameter))
                {
                    read.Read();
                    if (read.HasRows && !read.IsDBNull(read.GetOrdinal("idusuario")))
                    {


                        BEUsuario.IdUsuario = read.GetInt64(read.GetOrdinal("idusuario"));
                        BEUsuario.NombreUsuario = read.GetString(read.GetOrdinal("NombreUsuario"));
                        DNI = read.GetString(read.GetOrdinal("NumeroDocumento"));
                        error = read.GetBoolean(read.GetOrdinal("Error"));
                        respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }
                    else
                    {

                        //read.NextResult();
                        error = read.GetBoolean(read.GetOrdinal("Error"));
                        respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }
                }



            }

            catch (Exception ex)
            {
                throw ex;
            }

            return new MPCuenta { BEUsuario = BEUsuario, BECliente = new BECliente() { NumeroDocumento = DNI }, Error = error, Respuesta = respuesta };

        }

    }
}
