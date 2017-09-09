
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity.Base;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Entity
{
    public class PictureViewModels
    {
         
         public int CantidadDeregistros { get; set; }
        [Required]
        public Int64 idfoto { get; set; }
        [Required]
        public Int64 idproducto { get; set; }
        [Required]
        [MaxLength(50)]
        public string NombreImagen { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe se un numero natural")]
        public int posicionPortada { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcionImagen { get; set; }
        [Required]
        [MaxLength(50)]
        public string NombreProducto { get; set; }
        [Required]
        [MaxLength(500)]
        public string DescripcionProducto { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, 9999999999999999)]
        public int Stock { get; set; }
        [Required]
        public DateTime fechaproduccion { get; set; }
        [Required]
        public DateTime fechaexpiracion { get; set; }


    }
}
