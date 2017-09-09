using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VE.BusinessEntity.Base;
using WU.Compras.Publicidad.PE.Wallet.Config;

namespace WU.Compras.Publicidad.PE.Wallet.Models.Repository
{
    public class ImagenURl
    {

      
        public static async Task<string> GetURlpath(string conexion  ,string PathConfig , string listaNombreFoto )
        {
            string urlResponse =string.Empty;
        
             if(listaNombreFoto != null)
            {
                
                    using (var cliente = new HttpClient())
                    {
                        cliente.BaseAddress = new Uri(PathConfig);
                        cliente.DefaultRequestHeaders.Accept.Clear();
                        cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
                        HttpResponseMessage Response = await cliente.GetAsync("api/MediaImagen?Name="+ listaNombreFoto);
                        if (Response.IsSuccessStatusCode)
                        {
                            //UrlResponse = await Response.Content.ReadAsByteArrayAsync();
                            //UrlResponse = Response.Content.ReadAsByteArrayAsync().Result;
                          urlResponse = Response.RequestMessage.RequestUri.ToString();

                        }
                    }
                }
            return urlResponse;
        }
     
    }
   
    }

