using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using WU.Compras.Publicidad.PE.Wallet.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using VE.BusinessEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WU.Compras.Publicidad.PE.Wallet.Config;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Models.AccountViewModels;

namespace WU.Compras.Publicidad.PE.Wallet.Controllers
{


 
    public class AfiliacionController : Controller
    {
        private IAfilicion _iafilicion;
        private readonly ConnectionString _connectionString;
        private readonly EmailConfig ec;
        //    public AfiliacionController():this(new AfiliaRepositorio())
        //{
        //    }
        public AfiliacionController(IAfilicion iafilicionRepo, IOptions<ConnectionString> connectionstringAccessor , IOptions<EmailConfig> emailConfig)
        {
            _iafilicion = iafilicionRepo;
            _connectionString = connectionstringAccessor.Value;
            this.ec = emailConfig.Value;
        }

        [HttpGet]
        public IActionResult Afilia1()
        {
            var Afiliacion1 = new AfiliarClienteViewModel { AceptaPolitica = false, RecibeBoletin = false, RecibeTarjeta = false };
            //var 
            //ViewBag.Operador=
            string Conexion = _connectionString.DefaultConnection;
            var operador1 = _iafilicion.Lista_Operador(Conexion);
            //var operador = new AfiliaRepositorio().Lista_Operador();
            ViewBag.operador = operador1.ListaOperador;

            return View(Afiliacion1);
        }

        [HttpPost]
        public IActionResult Afilia1(AfiliarClienteViewModel Datos)
        {
            //Conexion a AppConfig.Json
            string Conexion = _connectionString.DefaultConnection;
            return RedirectToAction("Afilia2", Datos);
        }

        public IActionResult Afilia2(AfiliarClienteViewModel Datos)
        {
            //Conexion a AppConfig.Json
            string Conexion = _connectionString.DefaultConnection;
            var listaDepartamento = _iafilicion.ListaDepartamento(Conexion);
            ViewBag.listaDepartamento = listaDepartamento.listaUbigeo;
            return View(Datos);
        }

        [HttpPost]
        public IActionResult Afiliaa2(AfiliarClienteViewModel Datos)
        {
            string Conexion = _connectionString.DefaultConnection;
            var BEClienteTmp1 = new BEClienteTmp();
   
            BEClienteTmp1.AceptaPolitica = Datos.AceptaPolitica;
            BEClienteTmp1.ApellidoMaterno = Datos.ApellidoMaterno;
            BEClienteTmp1.ApellidoPaterno = Datos.ApellidoPaterno;
            BEClienteTmp1.CodigoAfiliacion = Guid.NewGuid();
            BEClienteTmp1.CodigoConfirmacionEmail = "";
            BEClienteTmp1.CodigoConfirmacionMovil = "";
            BEClienteTmp1.ConfirmoEmail = false;
            BEClienteTmp1.ConfirmoMovil = false;
            BEClienteTmp1.Direccion = Datos.xDireccion;
            BEClienteTmp1.Email = Datos.Email;
            BEClienteTmp1.FechaEmisionDocumento = Datos.FechaEmisionDocumento;
            BEClienteTmp1.FechaNacimiento = Datos.FechaNacimiento;
            BEClienteTmp1.FechaRegistro = new DateTime();
            BEClienteTmp1.Genero = Datos.Genero;
            BEClienteTmp1.IdCanalAfiliacion = 0;
            //BEClienteTmp1.IdClienteTmp = 0;
            BEClienteTmp1.IdDepartamento = Datos.IdDepartamento;
            BEClienteTmp1.IdDistrito = Datos.IdDistrito;
            BEClienteTmp1.IdEstadoCivil = Datos.IdEstadoCivil;
            BEClienteTmp1.IdPrefijoDireccion = 0;
            BEClienteTmp1.IdProvincia = Datos.IdProvincia;
            BEClienteTmp1.IdReferido = 0;
            BEClienteTmp1.IdStand = 0;
            BEClienteTmp1.IdTipoActivacion = 0;
            BEClienteTmp1.IdTipoCanalAfiliacion = 0;
            BEClienteTmp1.IdTipoDireccion = 0;
            BEClienteTmp1.IdTipoDocumento = 1;
            BEClienteTmp1.IdTipoEnvioTarjeta = 0;
            BEClienteTmp1.IdTipoOperador = Datos.IdTipoOperador;
            BEClienteTmp1.IMEI = "";
            BEClienteTmp1.Nombres = Datos.Nombres;
            BEClienteTmp1.NumeroDocumento = Datos.NumeroDocumento;
            BEClienteTmp1.NumeroIntentosFallidos = 0;
            BEClienteTmp1.NumeroIntentosFallidosReenvio = 0;
            BEClienteTmp1.NumeroMovil = Datos.NumeroMovil;
            BEClienteTmp1.NumeroReenvioPin = 0;
            BEClienteTmp1.PasswordHash = Datos.PasswordHash;
            BEClienteTmp1.RangoDiasEntrega = Datos.RangoDiasEntrega;
            BEClienteTmp1.RangoHorasEntrega = Datos.RangoHorasEntrega;
            BEClienteTmp1.RecibeBoletin = Datos.RecibeBoletin;
            BEClienteTmp1.RecibeTarjeta = Datos.RecibeTarjeta;
            BEClienteTmp1.Referencia = Datos.xReferencia;
            BEClienteTmp1.TelefonoFijo = "";
            BEClienteTmp1.Ubigeo = Datos.IdDepartamento + Datos.IdProvincia + Datos.IdDistrito;
            BEClienteTmp1.Usuario = Datos.Usuario;
            BEParametro Mensaje = _iafilicion.AfiliarClienteTemp(BEClienteTmp1, Conexion);
            if (Mensaje.xDescripcion == "AFILIACION CORRECTA")
            {
                var RespuestaAfiliacion = new MPDatos();

                RespuestaAfiliacion = _iafilicion.VericarCliente(Mensaje.iConstante, Conexion);
                if (RespuestaAfiliacion.Error == false)
                {
                    string Html = RespuestaAfiliacion.Html;
                    string Html1 = string.Empty;
                    string Html2 = string.Empty;
                    if (Html.Contains("@NOMBRE_AFILIADO"))
                    {
                        Html1 = Html.Replace("@NOMBRE_AFILIADO", RespuestaAfiliacion.BEClienteTmp.Nombres);
                        if (Html1.Contains("@CODIGO_EMAIL_CONFIRMACION"))
                        {
                            Html2= Html1.Replace("@CODIGO_EMAIL_CONFIRMACION", RespuestaAfiliacion.BEClienteTmp.CodigoConfirmacionMovil);
                        }
                    }
                    var servi = new EmailServiceRepositorio();
                    var correo = new BEemail();
                    correo.ToAdress = RespuestaAfiliacion.BEClienteTmp.Email;
                    correo.Subject = "Confirmacion De Afiliacion";
                    correo.Html = Html2;
                    
                    servi.SendEmailASync(correo, ec);
                }



                return RedirectToAction("Afiliacion3", "Afiliacion",Datos);



            }
            else { return RedirectToAction("Error", "Home"); }
       
        }

    
        public IActionResult Afiliacion3(AfiliarClienteViewModel Datos)
        {
            return View(Datos);

        }
        [HttpPost]
        public IActionResult Afiliacion3(string CodigoAfiliacion, AfiliarClienteViewModel Datos)
        {
            var valida = _iafilicion.ValidarCodigoAfiliacion(CodigoAfiliacion,_connectionString.DefaultConnection);
        
            if (valida.Error == false)
            {
                LoginViewModel LoginViewModel = new LoginViewModel();
                LoginViewModel.Password = Datos.Email;
                LoginViewModel.Email = Datos.PasswordHash;
                LoginViewModel.RememberMe = true;
               

                //TempData["Email"] = Email;
                //TempData["PasswordHash"] = PasswordHash;
                //Necesitamos ingreasar a las cuentas de ASP.net core 
                //var RegisterModel = _iafilicion.InsertUsuarioEntity(Datos.Email, Datos.PasswordHash);
                return RedirectToAction("Register_login", "Account", new { @Email = Datos.Email, @PasswordHash = Datos.PasswordHash} );
            }
            //var RegisterViewModel = new RegisterViewModel();
            else
            {
                return View();

            }

          
        }

        //[HttpPost]
        //[Route("Lista_Provincia")]
        public JsonResult Lista_Provincia(string IdDepartamento)
        {
            string Conexion = _connectionString.DefaultConnection;
            var listaProvincia = _iafilicion.Lista_Provincia(Conexion, IdDepartamento);
            return Json(new  SelectList(listaProvincia.listaUbigeo ,"IdProvincia", "Provincia"));  
        }
        public JsonResult Lista_Distrito(string IdDepartamento , string IdProvincia)
        {
            string Conexion = _connectionString.DefaultConnection;
            var listaDistrito = _iafilicion.Lista_Distrito(Conexion, IdDepartamento , IdProvincia);
            return Json(new SelectList(listaDistrito.listaUbigeo, "IdDistrito", "Distrito"));
        }




    }
}