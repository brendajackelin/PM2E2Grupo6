using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2Grupo6.Controllers
{

    public class Configuraciones
    {
        public const String IDFoursquare = "LOV0GYOEJSPB2SM1AC42V03AOUBLFHCMJM1EX5NENGMAWH3D";
        public const String SecretFoursquare = "IPH332TUAIEZ05VZTDRPHDHABJOWGMTPPKYLTG4YF5SO4SFL";
        public const String EndPointFoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v{4}";
    }


    public class Sitios
    {
        public static String getUrl(Double latitud, double longitud)
        {
            var url = String.Format(Configuraciones.EndPointFoursquare,
            latitud, longitud, Configuraciones.IDFoursquare, Configuraciones.SecretFoursquare, DateTime.Now.ToString("yyyyMMdd"));

            return url;
        }
    }

}
