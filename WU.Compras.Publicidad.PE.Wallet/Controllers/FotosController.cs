using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using Microsoft.AspNetCore.Http;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;
using System.IO;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity.Base;
using System.Net.Http;
using WU.Compras.Publicidad.PE.Wallet.Config;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WU.Compras.Publicidad.PE.Wallet.Controllers
{
    public class FotosController : Controller
    {
        // GET: /<controller>/
        private IHostingEnvironment _IEnviroment;
        private IFotos _IFotos;
        private readonly URLApiPath _URLApiPath;
        public FotosController(IHostingEnvironment _IEnviroment, IFotos _IFotos, IOptions<URLApiPath> _URLApiPath)
        {
            this._IEnviroment = _IEnviroment;
            this._IFotos = _IFotos;
            this._URLApiPath = _URLApiPath.Value;


        }
        [HttpGet]
        public IActionResult AgregarNuevaFoto()

        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AgregarNuevaFoto(
            IFormFile Files, PictureViewModels PictureViewModels)
        {
            string NombreImagenInicial = string.Empty;

           
            if (  Files != null)
            {
                if (Files.FileName.Contains(".jpg") || Files.FileName.Contains(".JPEG") || Files.FileName.Contains(".gif") || Files.FileName.Contains(".png") || Files.FileName.Contains(".tif"))
                {
                    NombreImagenInicial = Files.FileName.Replace(" ", "");
                    ///////
                    var Insert_Fotos = new PictureViewModels();

                    if (PictureViewModels != null)
                    {
                        var GetValue = new BEImagen();
                        var GetValuep = new BEProducto();
                        GetValue.descripcion = PictureViewModels.descripcionImagen;
                       
                        GetValue.posicionPortada = PictureViewModels.posicionPortada;
                        GetValuep.Descripcion = PictureViewModels.DescripcionProducto;
                        GetValuep.fechaexpiracion = PictureViewModels.fechaexpiracion;
                        GetValuep.fechaproduccion = PictureViewModels.fechaproduccion;
                        GetValuep.Nombre = PictureViewModels.NombreProducto;
                        GetValuep.Precio = PictureViewModels.Precio;
                        GetValuep.Stock = PictureViewModels.Stock;
                        NombreImagenInicial =  PictureViewModels.NombreImagen.Replace(" ", "") + Guid.NewGuid().ToString()+ NombreImagenInicial;
                        GetValue.Nombre = NombreImagenInicial;
                        Insert_Fotos = _IFotos.Insert_BEFoto(GetValue, GetValuep);

                        PictureViewModels.idfoto = Insert_Fotos.idfoto;
                        PictureViewModels.idproducto= Insert_Fotos.idproducto;
                        PictureViewModels.CantidadDeregistros = Insert_Fotos.CantidadDeregistros;
                        PictureViewModels.NombreImagen = NombreImagenInicial;

                    }
                    // solo guarda si se completo el insert de las entidades
                    var PathToSave = Path.Combine(_IEnviroment.WebRootPath, "images");
                    if (Files.Length > 0)
                    {
                        if (Insert_Fotos.CantidadDeregistros > 0)
                        {
                            //grabamos la imange en la APP
                            using (var SaveFile = new FileStream(Path.Combine(PathToSave,  NombreImagenInicial), FileMode.Create))
                            {
                                await Files.CopyToAsync(SaveFile);
                            }
                            //Enviamos A La API La imagen

                         SendToApi(Files,  NombreImagenInicial, PictureViewModels);
                        }


                    }
                }

            }

            /////////////////
            //var file = Request.;
            return RedirectToAction("ProductosLista", "Producto");
        }


        public void  SendToApi(IFormFile files , string Filename , PictureViewModels PictureViewModels)
        {
            try
            {

                // Armar un objeto JSON para Validar
                var URl = _URLApiPath.url.Trim();
                int status = 0;
                if (URl != null)
                {
                    using (var cliente = new HttpClient())
                    {
                        cliente.BaseAddress = new Uri(URl);
                        byte[] dataImagen;
                        string outputProductoFoto = JsonConvert.SerializeObject(PictureViewModels);
                        using (var data = new BinaryReader(files.OpenReadStream()))
                        {
                            dataImagen = data.ReadBytes((int)files.OpenReadStream().Length);
                              ByteArrayContent bytes = new ByteArrayContent(dataImagen);
                            MultipartFormDataContent multContent = new MultipartFormDataContent();
                            multContent.Add(bytes, "file", Filename);
                            HttpResponseMessage resul = cliente.PostAsync("api/CargarImagen?jsonProductoFoto="+outputProductoFoto+"", multContent).Result;
                            //var re= StatusCode(int.Parse( resul.StatusCode.ToString()));
                            var returnString =  resul.Content.ReadAsStringAsync();



                        }


                    }


                }
                
            }

            catch (Exception ex)
            {


                throw ex;
            }

         
        }
    }
}