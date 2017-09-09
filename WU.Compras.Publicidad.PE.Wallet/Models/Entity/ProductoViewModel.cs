using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Entity
{
    public class ProductoViewModel
    {
        [Key]
        public Int64 idproducto { get; set; }
        [Required(ErrorMessage = "Debe Ingresar nombre del producto")]
        [MaxLength(50, ErrorMessage = "no debe exceder de los 50 letras")]
        public string Nombre { get; set; }
        public Int64 idcategoria { get; set; }
        public int idestado { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string LineaProducto { get; set; }
        public Guid codigo { get; set; }

    }
}