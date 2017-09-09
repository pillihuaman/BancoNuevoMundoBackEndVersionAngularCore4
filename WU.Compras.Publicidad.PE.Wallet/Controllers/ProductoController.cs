using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WU.Compras.Publicidad.PE.Wallet.Config;
using Microsoft.Extensions.Options;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using WU.Compras.Publicidad.PE.Wallet.Models.Repository;
using VE.BusinessEntity.Base;
using VE.BusinessEntity;
using WU.Compras.Publicidad.PE.Wallet.Extenders;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using WU.Compras.Publicidad.PE.Wallet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace WU.Compras.Publicidad.PE.Wallet.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ConnectionString _ConetionString;
        private readonly URLApiPath _URLApiPath;
        private readonly IProducto _Producto;
        public readonly UserManager<ApplicationUser> _userManager;
        public ProductoController(IOptions<ConnectionString> _ConetionString, IProducto _Producto, IOptions<URLApiPath> _URLApiPath, UserManager<ApplicationUser> _userManager)
        {
            this._ConetionString = _ConetionString.Value;
            this._Producto = _Producto;
            this._URLApiPath = _URLApiPath.Value;
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            List<ProductoViewModel> listaProducto = new List<ProductoViewModel>();
            var ProductoViewModel = new ProductoViewModel();
            ProductoViewModel.codigo = new Guid();
            ProductoViewModel.Descripcion = "productos de pan llevar";

            listaProducto.Add(ProductoViewModel);
            //var Collecion =;
            IEnumerable<ProductoViewModel> IEnumeProducto = listaProducto;

            return RedirectToAction("ProductosLista");
            //var DataProducto=
            //return View(IEnumeProducto);
        }

        //[ResponseCache(CacheProfileName = "CacheDuration")]
        //[ResponseCache(Location = ResponseCacheLocation.Any,
        //            Duration = 10000)]  
        [AllowAnonymous]
      [EnableCors("Corspolicy")]
      
        public async Task<JsonResult> ProductosLista()
        {
            var GetnameFoto = _Producto.GetLisRutaProducto(0, _ConetionString.DefaultConnection, "");

            foreach (var s in GetnameFoto)
            {
                ////s.rutafoto
                s.BEFoto.rutafoto = await ImagenURl.GetURlpath(_ConetionString.DefaultConnection, _URLApiPath.url, s.BEFoto.Nombre);
                s.Producto.codigo = await Util.EncryptToBase64String(s.Producto.codigo);
            }
            IEnumerable<MPProducto> lista = GetnameFoto;
            return Json(lista);

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ShowProductoDetalle(string Codigo, string rutafoto)
        {
            if ((Codigo != null || Codigo != string.Empty) && (rutafoto != null || rutafoto != string.Empty))
            {
                string codigo = string.Empty;
                codigo = await Util.DescEncryptToBase64String(Codigo);

                var ShowDetalleProducto = _Producto.ShowDetalleProducto(_ConetionString.DefaultConnection, codigo);
                ViewBag.URLimagen = rutafoto;
                return View(ShowDetalleProducto);

            }
            else
            {

                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> VerDetalleCompra(string objeCarrtito)
        {
            ///////////////
            bool ValidaProducto = false;
            Queue<BEPedido> BEPedido = new Queue<BEPedido>();
            if (objeCarrtito != null)
            {
                var userID = _userManager.GetUserId(User);
                var json = JsonConvert.DeserializeObject(objeCarrtito);
                List<BEPedido> LstPedido = JsonConvert.DeserializeObject<List<BEPedido>>(objeCarrtito);
                foreach (BEPedido ped in LstPedido)
                {
                    ValidaProducto = ped.Error;

                    if (ped.Error != true)
                    {
                        var codigo = await Util.DescEncryptToBase64String(ped.Token.ToString().Trim());
                        ped.Codigo = Guid.Parse(codigo);
                        ped.IDusuario = userID;
                    }
                }
                var ValidaPedidos = _Producto.ValidarPedido(new Queue<BEPedido>(LstPedido));
                BEPedido = ValidaPedidos;
            }
            /////////////////////
            var objtBePedidoSinError = new Queue<BEPedido>(BEPedido.Where(p => p.Error != true));

            if (objtBePedidoSinError.Count > 0)
            {
                List<Guid> Codigo = new List<Guid>();
                string JsonObjeto = string.Empty;
                foreach (BEPedido pedido in objtBePedidoSinError)
                {
                    Codigo.Add(pedido.Codigo);
                }
                if (Codigo.Count > 0)
                {
                    var jsonObject = JsonConvert.SerializeObject(Codigo);
                    JsonObjeto = jsonObject;
                }
                var JsonResul = VerDetallePedido(JsonObjeto);
                return Json(JsonConvert.SerializeObject(JsonResul));

            }

            else
            {
                return View();
            }


        }
        public async  Task<IEnumerable<BEPedido>> VerDetallePedido(string JsonObjeto)
        {
            Queue<Guid> Codigo = null;
            IEnumerable<BEPedido> lstBEPedido = null;
            if (JsonObjeto != null || JsonObjeto != string.Empty)
            {
                Codigo = JsonConvert.DeserializeObject<Queue<Guid>>(JsonObjeto);
                var lstPedidoDetallecola = _Producto.ListaPedidoValidado(Codigo);
                foreach (BEPedido lst in lstPedidoDetallecola)
                {
                    lst.Token=  await Util.EncryptToBase64String(lst.Codigo.ToString());

                }
                lstBEPedido = lstPedidoDetallecola;
            }
            return  lstBEPedido;
        }

        [HttpPost]
        public IActionResult GenerarPedido(string jsonPedido)
        {
            return View(); 

        }
        [HttpPost]
        public IActionResult GenerarPedido()
        {
            return View();        }
    }
}