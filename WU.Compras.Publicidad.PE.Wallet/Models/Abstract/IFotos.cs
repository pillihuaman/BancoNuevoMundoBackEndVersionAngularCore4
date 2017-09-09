
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity;
using WU.Compras.Publicidad.PE.Wallet.Models.Entity.Base;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Abstract
{
     public interface IFotos
    {
        PictureViewModels Insert_BEFoto(BEImagen  BEImagen , BEProducto BEProducto);
    }
}
