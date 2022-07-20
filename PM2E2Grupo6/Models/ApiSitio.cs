using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2Grupo6.Models
{
    public static class UrlApi
    {
        public static string ip = "cinepolishn.000webhostapp.com";
        public static string web = "RestAPI";


        //Apis clase sitios
        public static string getEndPoint = "listasitios.php"; //GET
        public static string postEndPoint = "crear.php"; //POST
        public static string updateEndPoint = "actualizarsitio.php"; //UPDATE
        public static string deleteEndPoint = "eliminarsitio.php"; //DELETE

    }

    public static class ApiSitio
    {
        public static string GETSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.getEndPoint);
        public static string POSTSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.postEndPoint);
        public static string UPDATESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.updateEndPoint);
        public static string DELETESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.deleteEndPoint);

    }

    public class Sitio
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string Uri { get; set; }
        public string Url { get; set; }
    }

    public class SitioRoot
    {
        public IList<Sitio> sitios { get; set; }
    }

    /*public class UrlApi
    {

        public static string ip = "sitiosweb2021.000webhostapp.com";
        public static string web = "RestAPI";


        //Apis clase sitios
        public static string getEndPoint = "listasitios.php"; //GET
        public static string postEndPoint = "Crear.php"; //POST
        public static string updateEndPoint = "actualizarsitio.php"; //UPDATE
        public static string deleteEndPoint = "eliminarSitio.php"; //DELETE

        public static string GETSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.getEndPoint);
        public static string POSTSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.postEndPoint);
        public static string UPDATESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.updateEndPoint);
        public static string DELETESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.deleteEndPoint);

    }
    /*
    public static class ApiSitio
    {
        
    }*/

    /*public class Sitio
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

    }

    public class SitioRoot
    {
        public IList<Sitio> sitios { get; set; }
    }*/
    /*public static String ApiGetListSit = string.Format(GETSitioList, ip, web, getEndPoint);
    public static String ApiPostSit = string.Format(POSTSitioList, ip, web, postEndPoint);*/

}
