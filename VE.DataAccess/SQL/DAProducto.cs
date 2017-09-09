using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity;
using System.Data;
using System.Data.SqlClient;
using VE.BusinessEntity.Base;

namespace VE.DataAccess.SQL
{
    public class DAProducto
    {

        public Queue<MPProducto> GetLisRutaProducto(int idFoto, string Conexion, string RutaFotos)
        {



            Queue<MPProducto> lstBEfotoProducto = new Queue<MPProducto>();


            try
            {

                var Parameter = new SqlParameter[4];
                Parameter[0] = new SqlParameter("@CallAPP", SqlDbType.VarChar) { Value = "APP_Publicidad" };
                Parameter[1] = new SqlParameter("@idfoto", SqlDbType.Int) { Value = idFoto };
                Parameter[2] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[3] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(Conexion, CommandType.StoredProcedure, "dbo.ListarRankingImagenes", Parameter))
                {

                    while (read.Read() && read.HasRows && !read.IsDBNull(read.GetOrdinal("hashCode")))
                    {
                        //MPProducto BEfotoProducto = new MPProducto();
                        MPProducto MPObjeto = new MPProducto();
                        BEFotos BEFoto = new BEFotos();
                        BEProducto Producto = new BEProducto();

                        BEFoto.hashCode = read.GetString(read.GetOrdinal("hashCode"));
                        BEFoto.idfoto = read.GetInt64(read.GetOrdinal("idfoto"));
                        BEFoto.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                        Producto.codigo = read.GetString(read.GetOrdinal("codigo"));
                        Producto.Descripcion = read.GetString(read.GetOrdinal("Descripcion"));
                        Producto.idproducto = read.GetInt64(read.GetOrdinal("idproducto"));
                        Producto.Precio = read.GetDecimal(read.GetOrdinal("Precio"));
                        Producto.idfoto = read.GetInt64(read.GetOrdinal("idfoto"));
                        Producto.Nombre = read.GetString(read.GetOrdinal("NombreProducto"));
                        BEFoto.rutafoto = RutaFotos;
                        MPObjeto.BEFoto = BEFoto;
                        MPObjeto.Producto = Producto;
                        //BEfotoProducto.Error = false;
                        //BEfotoProducto.Respuesta = "OK";
                        lstBEfotoProducto.Enqueue(MPObjeto);


                    }
                    //else
                    //{

                    //    //read.NextResult();
                    //    error = read.GetBoolean(read.GetOrdinal("Error"));
                    //    respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    //}
                }



            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstBEfotoProducto;

        }
        public BEProducto ShowDetalleProducto(string conexion, string key)
        {
            BEProducto BEProducto = new BEProducto();
            try
            {
                var Parameter = new SqlParameter[3];
                Parameter[0] = new SqlParameter("@key", SqlDbType.VarChar) { Value = key };
                Parameter[1] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                Parameter[2] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                using (var read = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "dbo.GetDetalleProducto", Parameter))
                {

                    while (read.Read() && read.HasRows && !read.IsDBNull(read.GetOrdinal("codigo")))
                    {
                        BEProducto.idproducto = read.GetInt64(read.GetOrdinal("idproducto"));
                        BEProducto.idcategoria = read.GetInt64(read.GetOrdinal("idcategoria"));
                        BEProducto.Descripcion = read.GetString(read.GetOrdinal("Descripcion"));
                        BEProducto.codigo = read.GetString(read.GetOrdinal("codigo"));
                        BEProducto.Stock = read.GetInt32(read.GetOrdinal("Stock"));
                        BEProducto.Precio = read.GetDecimal(read.GetOrdinal("Precio"));
                        BEProducto.fechaproduccion = read.GetDateTime(read.GetOrdinal("fechaproduccion"));
                        BEProducto.fechaexpiracion = read.GetDateTime(read.GetOrdinal("fechaexpiracion"));
                        BEProducto.Error = read.GetBoolean(read.GetOrdinal("Error"));
                        BEProducto.Respuesta = read.GetString(read.GetOrdinal("Respuesta"));

                    }


                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            return BEProducto;

        }
    }
}
