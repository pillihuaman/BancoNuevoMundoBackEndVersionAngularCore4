using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using VE.BusinessLogical;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Repository
{
    public class ProductoRepositorio : IProducto
    {
        //public MPProducto GetLisRutaProducto(int NummeroPagina)
        //{

        //     //return new 

        //}


        public Queue<MPProducto> GetLisRutaProducto(int idFoto, string Conexion, string RutaFotos)
        {
            return new BLProducto().GetLisRutaProducto(idFoto, Conexion, RutaFotos);
        }

        public Queue<BEPedido> ListaPedidoValidado(Queue<Guid> Codigoproducto)
        {
            Queue<BEPedido> lstBEPedidoRespuesta = new Queue<BEPedido>();
            try
            {
                if (Codigoproducto.Count > 0)
                {
                    foreach (Guid GUI in Codigoproducto)
                    {
                        if (GUI != null)
                        {
                            WU.Compras.Publicidad.PE.Wallet.Data.Conecta Conecta = new WU.Compras.Publicidad.PE.Wallet.Data.Conecta();
                            string Conexion = Conecta.GetConexion().ConnectionString;
                            using (var conexion = new SqlConnection())
                            {
                                var Parameter = new SqlParameter[3];
                                Parameter[0] = new SqlParameter("@codigo", SqlDbType.UniqueIdentifier) { Value = GUI };
                                Parameter[1] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                                Parameter[2] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                                using (var read = VE.DataAccess.SqlHelper.ExecuteReader(Conexion, CommandType.StoredProcedure, "dbo.Listar_PedidosValidados", Parameter))
                                {

                                    read.Read();
                                    if (read.HasRows)
                                    {
                                        BEPedido BEPedido = new BEPedido();
                                        BEPedido.Codigo = read.GetGuid(read.GetOrdinal("codigo"));
                                        BEPedido.Nombre = read.GetString(read.GetOrdinal("Nombre"));
                                        BEPedido.Total = read.GetDecimal(read.GetOrdinal("Precio"));
                                        BEPedido.fechaexpiracion = read.GetDateTime(read.GetOrdinal("fechaexpiracion"));
                                        BEPedido.fechaproduccion = read.GetDateTime(read.GetOrdinal("fechaproduccion"));
                                        BEPedido.Error = read.GetBoolean(read.GetOrdinal("Error"));
                                        BEPedido.respuesta = read.GetString(read.GetOrdinal("Respuesta"));
                                        lstBEPedidoRespuesta.Enqueue(BEPedido);
                                    }
                                    else
                                    {
                                        read.NextResult();
                                        BEPedido BEPedido = new BEPedido();
                                        BEPedido.Error = read.GetBoolean(read.GetOrdinal("Error"));
                                        BEPedido.respuesta = read.GetString(read.GetOrdinal("Respuesta"));
                                        lstBEPedidoRespuesta.Enqueue(BEPedido);


                                    }
                                }
                            }


                        }
                        else
                        {

                            lstBEPedidoRespuesta.Enqueue(new BEPedido { Error = true, respuesta = "EL ID USUARIO ES ERRADO O EL ID PRODUCTO NO CUMPLE CON LOS PARAMETROS" });

                        }
                    }

                }
                else
                {
                    return new Queue<BEPedido>();
                }
            }

            catch (Exception ex)
            {

                lstBEPedidoRespuesta.Enqueue(new BEPedido { Error = true, respuesta = "Error no controlado " + ex.Message });
            }
            return lstBEPedidoRespuesta;
        }

        public BEProducto ShowDetalleProducto(string Conexion, string key)
        {
            return new BLProducto().ShowDetalleProducto(Conexion, key);
        }

        public Queue<BEPedido> ValidarPedido(Queue<BEPedido> lstBEPedido)
        {
            Queue<BEPedido> lstBEPedidoRespuesta = new Queue<BEPedido>();
            try
            {
               
                if (lstBEPedido.Count > 0)
                {
                    foreach (BEPedido BEPedido in lstBEPedido)
                    {
                        if (BEPedido.IDusuario != string.Empty && (BEPedido.Codigo != null))
                        {
                            WU.Compras.Publicidad.PE.Wallet.Data.Conecta Conecta = new WU.Compras.Publicidad.PE.Wallet.Data.Conecta();
                            string Conexion = Conecta.GetConexion().ConnectionString;
                            using (var conexion = new SqlConnection())
                            {

                                var Parameter = new SqlParameter[4];
                                Parameter[0] = new SqlParameter("@IDusuario", SqlDbType.VarChar) { Value = BEPedido.IDusuario };
                                Parameter[1] = new SqlParameter("@codigo", SqlDbType.UniqueIdentifier) { Value = BEPedido.Codigo };
                                Parameter[2] = new SqlParameter("@Error", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                                Parameter[3] = new SqlParameter("@Respuesta", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                                using (var read = VE.DataAccess.SqlHelper.ExecuteReader(Conexion, CommandType.StoredProcedure, "dbo.ValidarPedido", Parameter))
                                {
                                    while (read.Read())
                                    {

                                        BEPedido.Error = read.GetBoolean(read.GetOrdinal("Error"));
                                        BEPedido.respuesta = read.GetString(read.GetOrdinal("Respuesta"));
                                        lstBEPedidoRespuesta.Enqueue(BEPedido);
                                    }
                                }
                            }


                        }
                        else
                        {

                            lstBEPedidoRespuesta.Enqueue(new BEPedido { Error = true, respuesta = "EL ID USUARIO ES ERRADO O EL ID PRODUCTO NO CUMPLE CON LOS PARAMETROS" });

                        }
                    }
                  
                }
                else
                {
                    return new Queue<BEPedido>();
                }
            }

            catch (Exception ex)
            {

                lstBEPedidoRespuesta.Enqueue(new BEPedido { Error = true, respuesta = "Error no controlado " + ex.Message });
            }
            return lstBEPedidoRespuesta;
        }
        }
}

