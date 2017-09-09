using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using System.Collections;

namespace VE.BusinessEntity
{
    public class MPDatos
    {
        public BECliente Afiliacion { get; set; }
        public BEClienteCanalAfiliacion CanalAfiliacion { get; set; }
        public BEOperadores Operador { get; set; }
        public BEClienteEstadoCivil estadoCivil { get; set; }
        public BEClienteTmp BEClienteTmp { get; set; }
        public BEUbigeo BEUbigeo { get; set; }
        public BEClienteDireccion BEClienteDireccion { get; set; }
        public BEPedido BEPedido { get; set; }
        public BEUsuario BEUsuario { get; set; }
        public IList<BEOperadores> ListaOperador { get; set; }
        public IList<BEUbigeo> listaUbigeo { get; set; }
        public bool Error { get; set; }
        public string Respuesta { get; set; } 
        public string Mensaje { get; set; }
         public string Html { get; set; }





    }
    public struct Respuesta
    {
        public const string RespuestaOK = "Respuesta-OK";
        public const string ResouestaError = "Respuesta-Fail";

    }
}
