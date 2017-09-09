using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE.BusinessEntity.Base
{
    public class BEestado
    {

        public int IdEstado { get; set; }
        public int IdEstadoGrupo { get; set; }
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Comentario { get; set; }
        public string EstadoSiguiente { get; set; }


    }
}
