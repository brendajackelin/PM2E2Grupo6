using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM2E2Grupo6.Controllers
{

    public class FoursquareController
    {

        public async static Task<List<Models.ApiFourSquare.Venue>> getListSites(Double latitud, Double longitud)
        {
            List<Models.ApiFourSquare.Venue> sitioscerca = new List<Models.ApiFourSquare.Venue>();

            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync(Controllers.Sitios.getUrl(latitud, longitud));

                if (respuesta.IsSuccessStatusCode)
                {
                    var json = respuesta.Content.ReadAsStringAsync().Result;

                    var lugares = JsonConvert.DeserializeObject<Models.ApiFourSquare.VenuesRest>(json);

                    sitioscerca = lugares.response.venues as List<Models.ApiFourSquare.Venue>;

                }

            }

            return sitioscerca;
        }

    }
}
