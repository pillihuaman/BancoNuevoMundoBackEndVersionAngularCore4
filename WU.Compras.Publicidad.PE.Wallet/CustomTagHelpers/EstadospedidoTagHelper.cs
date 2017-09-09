using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU.Compras.Publicidad.PE.Wallet.CustomTagHelpers
{
    public class EstadospedidoTagHelper: TagHelper
    {
        public bool estado { get; set; }
        public override Task ProcessAsync(TagHelperContext Context , TagHelperOutput output)
        {
            string Img = string.Empty;
            if (estado != false)
            {
                Img = "Aprobado.png";
            }
            else
            {
                Img = "Rechazado.png";

            }
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "panel");
            Img = $"/ImagenesSistema/{Img}"; //ruta relativa de la imagen
            StringBuilder htmlString = new StringBuilder();
            htmlString.Append($"<img src='{Img}' />");
            htmlString.Append($"<span class='label label-default'>{this.estado}</span>");
            output.Content.AppendHtml(htmlString.ToString());
            return base.ProcessAsync(Context, output);
        }


    }
}
