using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE.BusinessEntity;
using VE.BusinessEntity.Base;
using VE.DataAccess.SQL;

namespace VE.BusinessLogical
{
    public class BLAfilia
    {
        public MPDatos Lista_Operador(string cadena)
        {
            return new DAafiliacion().Lista_Operador(cadena);
            //return new AfiliacionDA().AgregarCliente(codigoAfiliacion);
        }
        public MPDatos ListaDepartamento(string cadena)
        {
             return new DAafiliacion().List_Departamento(cadena);
        }

        public MPDatos Lista_Provincia(string cadena, string IdDepartamento)
        {

            return new DAafiliacion().List_Provincia(cadena, IdDepartamento);
        }
        public MPDatos Lista_Distrito(string conxeion, string iddepartamento, string idprovincia)
        {

            return new DAafiliacion().List_Distrito(conxeion, iddepartamento, idprovincia);

        }
        public BEParametro insertar_clienteTemp(BEClienteTmp datosAfilia, string conecta)
        {
            return new DAafiliacion().insertar_clienteTemp(datosAfilia,conecta);


        }

        public MPDatos VericarCliente(Int32 IdClienteTmp, string conecta)
        {
            return new DAafiliacion().VericarCliente(IdClienteTmp, conecta);


        }

        public MPDatos ValidarCodigoAfiliacion(string codiafiliacion, string conecta)
        {
            return new DAafiliacion().ValidarCodigoAfiliacion(codiafiliacion, conecta);
        }
    }
}
