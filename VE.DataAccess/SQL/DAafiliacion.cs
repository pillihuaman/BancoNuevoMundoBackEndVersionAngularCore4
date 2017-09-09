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
    public class DAafiliacion
    {
 
        public MPDatos Lista_Operador(string Conexionstring)
        {
            try
            { 
             var MPDatos = new MPDatos();

                    using (var read = SqlHelper.ExecuteReader(Conexionstring, CommandType.StoredProcedure, "dbo.ListarOperadores"))
                    {
                        var opera = new List<BEOperadores>();
                        
                        while (read.Read())
                        {
                            var operador = new BEOperadores();
                        operador.IdTipoOperador = read.GetInt32(read.GetOrdinal("IdTipoOperador"));
                            operador.TipoOperador = read.GetString(read.GetOrdinal("TipoOperador"));
                            opera.Add(operador);
                            MPDatos.ListaOperador = opera;

                        }
          
            }
            return MPDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MPDatos List_Departamento(string Conexionstring)
        {
            try
            {
                var MPDatos = new MPDatos();
                using (SqlDataReader read =SqlHelper.ExecuteReader(Conexionstring,CommandType.StoredProcedure, "dbo.Listar_Ubigeo"))
                        {
                            var listaDepartamento = new List<BEUbigeo>();
                    while (read.Read())
                    {
                                var departamento = new BEUbigeo();
                                departamento.IdDepartamento = read.GetString(read.GetOrdinal("IdDepartamento"));
                               departamento.Departamento = read.GetString(read.GetOrdinal("Departamento"));
                                listaDepartamento.Add(departamento);
                                MPDatos.listaUbigeo = listaDepartamento;
                       
                            }

                    //    }

                    //}

                }
                return MPDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
        public MPDatos List_Provincia(string Conexionstring ,string IdDepartamento)
        {
            try
            {
                var MPDatos = new MPDatos();
            
                        var Parameter = new SqlParameter[1];
                        Parameter[0] = new SqlParameter("@IdDepartamento", SqlDbType.VarChar, 2) { Value = IdDepartamento };
                  
                        using (SqlDataReader read = SqlHelper.ExecuteReader(Conexionstring,CommandType.StoredProcedure, "dbo.Listar_Ubige_provincia", Parameter))
                        {
                            var listaProvincia = new List<BEUbigeo>();
                    while (read.Read())
                    {
                                var provincia = new BEUbigeo();
                        provincia.IdProvincia = read.GetString( read.GetOrdinal("IdProvincia"));
                        provincia.Provincia = read.GetString( read.GetOrdinal("Provincia"));
                                listaProvincia.Add(provincia);
                        MPDatos.listaUbigeo = listaProvincia;
                       
                            }
                }
                return MPDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }



        public MPDatos List_Distrito(string Conexionstring, string IdDepartamento ,string IdProvincia)
        {
            try
            {
                var MPDatos = new MPDatos();

                var Parameter = new SqlParameter[2];
                Parameter[0] = new SqlParameter("@IdDepartamento", SqlDbType.NVarChar, 2) { Value = IdDepartamento };
                Parameter[1] = new SqlParameter("@IdProvincia", SqlDbType.NVarChar, 2) { Value = IdProvincia };
           
                using (SqlDataReader read = SqlHelper.ExecuteReader(Conexionstring, CommandType.StoredProcedure, "dbo.Listar_Ubige_Distrito", Parameter))
                {
                    var distrito = new List<BEUbigeo>();
                    while (read.Read())
                    {
                        var distritobj = new BEUbigeo();
                        distritobj.IdDistrito = read.GetString(read.GetOrdinal("IdDistrito"));
                        distritobj.Distrito= read.GetString(read.GetOrdinal("Distrito"));
                        distrito.Add(distritobj);
                        MPDatos.listaUbigeo = distrito;

                    }
                }
                return MPDatos;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public BEParametro insertar_clienteTemp(BEClienteTmp datos ,string conexion)
        {
            BEParametro mensaje=null ;
            try
            {
                var Parameter = new SqlParameter[40];
                Parameter[0] = new SqlParameter("@Nombres", SqlDbType.NVarChar, 100) { Value = datos.Nombres };
                Parameter[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.NVarChar, 100) { Value = datos.ApellidoPaterno };
                Parameter[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.NVarChar, 100) { Value = datos.ApellidoMaterno };
                Parameter[4] = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = 1 };
                Parameter[5] = new SqlParameter("@NumeroDocumento", SqlDbType.NVarChar, 20) { Value = datos.NumeroDocumento };
                Parameter[6] = new SqlParameter("@FechaEmisionDocumento", SqlDbType.NVarChar, 7) { Value = datos.FechaEmisionDocumento };
                Parameter[7] = new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = datos.Email };
                Parameter[8] = new SqlParameter("@IdTipoOperador", SqlDbType.Int) { Value = datos.IdTipoOperador };
                Parameter[9] = new SqlParameter("@NumeroMovil", SqlDbType.NVarChar, 20) { Value = datos.NumeroMovil };
                Parameter[10] = new SqlParameter("@IMEI", SqlDbType.NVarChar, 50) { Value = "0000000000000000000000000000" };
                Parameter[11] = new SqlParameter("@FechaNacimiento", SqlDbType.Date) { Value = datos.FechaNacimiento };
                Parameter[12] = new SqlParameter("@IdEstadoCivil", SqlDbType.Int) { Value = datos.IdEstadoCivil };
                Parameter[13] = new SqlParameter("@Genero", SqlDbType.Bit) { Value = 1 };//datos.Genero  };
                Parameter[14] = new SqlParameter("@RecibeBoletin", SqlDbType.Bit) { Value = datos.RecibeBoletin };
                Parameter[15] = new SqlParameter("@AceptaPolitica", SqlDbType.Bit) { Value = datos.AceptaPolitica };
                Parameter[16] = new SqlParameter("@RecibeTarjeta", SqlDbType.Bit) { Value = datos.RecibeTarjeta };
                Parameter[17] = new SqlParameter("@IdTipoCanalAfiliacion", SqlDbType.Int) { Value = 1 };
                Parameter[18] = new SqlParameter("@IdTipoEnvioTarjeta", SqlDbType.Int) { Value = 1 };
                Parameter[19] = new SqlParameter("@IdStand", SqlDbType.Int) { Value = 1 };
                Parameter[20] = new SqlParameter("@Ubigeo", SqlDbType.NVarChar, 6) { Value = datos.IdDepartamento + datos.IdProvincia + datos.IdDistrito };
                Parameter[21] = new SqlParameter("@IdTipoDireccion", SqlDbType.Int) { Value = datos.IdTipoDireccion };
                Parameter[22] = new SqlParameter("@IdPrefijoDireccion", SqlDbType.Int) { Value = 1 };
                Parameter[23] = new SqlParameter("@Direccion", SqlDbType.NVarChar, 100) { Value = datos.Direccion };
                Parameter[24] = new SqlParameter("@Referencia", SqlDbType.NVarChar, 100) { Value = datos.Referencia };
                Parameter[25] = new SqlParameter("@TelefonoFijo", SqlDbType.NVarChar, 15) { Value = "000000" };
                Parameter[26] = new SqlParameter("@RangoDiasEntrega", SqlDbType.NVarChar, 20) { Value = datos.RangoDiasEntrega };
                Parameter[27] = new SqlParameter("@RangoHorasEntrega", SqlDbType.NVarChar, 20) { Value = datos.RangoHorasEntrega };
                Parameter[28] = new SqlParameter("@ConfirmoMovil", SqlDbType.Bit) { Value = 0 };
                Parameter[29] = new SqlParameter("@ConfirmoEmail", SqlDbType.Bit) { Value = 0 };
                Parameter[30] = new SqlParameter("@CodigoConfirmacionMovil", SqlDbType.NVarChar, 10) { Value = "" };
                Parameter[31] = new SqlParameter("@CodigoConfirmacionEmail", SqlDbType.NVarChar, 10) { Value = "" };
                Parameter[32] = new SqlParameter("@NumeroReenvioPin", SqlDbType.Int) { Value = 0 };
                Parameter[33] = new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 200) { Value =  datos.PasswordHash };
                Parameter[34] = new SqlParameter("@NumeroIntentosFallidos", SqlDbType.Int) { Value = datos.NumeroIntentosFallidos };
                Parameter[35] = new SqlParameter("@NumeroIntentosFallidosReenvio", SqlDbType.Int) { Value = datos.NumeroIntentosFallidosReenvio };
                Parameter[36] = new SqlParameter("@CodigoAfiliacion", SqlDbType.UniqueIdentifier, 200) { Value = datos.CodigoAfiliacion };// "6F9619FF-8B86-D011-B42D-00C04FC964FF" };//datos.CodigoAfiliacion};
                //Parameter[37] = new SqlParameter("@FechaRegistro", SqlDbType.NVarChar, 2) { Value =  };
                //Parameter[38] = new SqlParameter("@FechaModificacion", SqlDbType.NVarChar, 2) { Value =  };
                //Parameter[39] = new SqlParameter("@IdReferido", SqlDbType.NVarChar, 2) { Value =  };
                Parameter[37] = new SqlParameter("@Usuario", SqlDbType.NVarChar, 20) { Value = datos.Nombres + datos.ApellidoPaterno };
                Parameter[38] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                Parameter[39] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                using (SqlDataReader read = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "dbo.Insertar_ClienteTemp", Parameter))
                {
                    while (read.Read())
                    {
                        mensaje = new BEParametro();
                        //read.NextResult();
                        mensaje.iConstante = read.GetInt32(read.GetOrdinal("IdClienteTmp"));
                        mensaje.xDescripcion = read.GetString(read.GetOrdinal("MENSAJE"));
                        mensaje.lDatoInt = read.GetBoolean(read.GetOrdinal("Error"));



                    }


                }

                return mensaje;
            }

            catch (Exception ex)
            {
                mensaje = new BEParametro();
                mensaje.xDescripcion = ex.ToString();
                return mensaje;
                throw ex;
            }



        }

        public MPDatos VericarCliente(Int32 IDIdClienteTmp, string conexion)
        {
            bool error = false;
            string respuesta = "";
            var idclienteAfiliacion = new BEClienteTmp();
            string Html = string.Empty;
            try
            {

                var Parameter = new SqlParameter[3];
                Parameter[0] = new SqlParameter("@IdClienteTmp", SqlDbType.BigInt) { Value = IDIdClienteTmp };
                Parameter[1] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[2] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "dbo.validarAfiliacion", Parameter))
                {
                    read.Read();
                    if (read.HasRows && !read.IsDBNull(read.GetOrdinal("IdClienteTmp")))
                    {
                        
                        
                        idclienteAfiliacion.IdClienteTmp = read.GetInt64(read.GetOrdinal("IdClienteTmp"));
                        idclienteAfiliacion.Nombres = read.GetString(read.GetOrdinal("NOMBRE_AFILIADO"));
                        idclienteAfiliacion.CodigoConfirmacionMovil = read.GetString(read.GetOrdinal("CodigoAfiliacion"));
                        idclienteAfiliacion.Email = read.GetString(read.GetOrdinal("Email"));
                        Html = read.GetString(read.GetOrdinal("Html"));

                    }
                    read.NextResult();
                    error = (bool)Parameter[1].Value;
                    respuesta = Parameter[2].Value.ToString();

                }



            }

            catch (Exception ex)
            {
                throw ex;
            }

            return new MPDatos { BEClienteTmp = idclienteAfiliacion, Error = error, Respuesta = respuesta,Html= Html };

        }

        public MPDatos ValidarCodigoAfiliacion(string codigoafiliacion, string conexion)
        {

            bool error = false;
            string respuesta = "";
            var Cliente = new BECliente();
  
            try
            {

                var Parameter = new SqlParameter[3];
                Parameter[0] = new SqlParameter("@CodigoAfiliacion", SqlDbType.VarChar,8) { Value = codigoafiliacion };
                Parameter[1] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[2] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "dbo.ValidarCodigoAfiliacion", Parameter))
                {
                    read.Read();
                    if (read.HasRows && !read.IsDBNull(read.GetOrdinal("idcliente")))
                    {


                        Cliente.IdCliente = read.GetInt64(read.GetOrdinal("idcliente"));
                        error = read.GetBoolean(read.GetOrdinal("Error"));
                        respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }
             

                }



            }

            catch (Exception ex)
            {
                throw ex;
            }

            return new MPDatos {Afiliacion = Cliente, Error = error, Respuesta = respuesta};

        }

    }
}
