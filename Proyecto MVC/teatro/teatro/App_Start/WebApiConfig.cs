using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace teatro
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            // Sería algo similar a lo que se ahce a la hora de serializar un archivo xml.            
            // Limpia las configuraciones 
            GlobalConfiguration.Configuration.Formatters.Clear();
            // Agrega un nuevo formater, en este caso del tipo JsonMedia
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            // Establece el contrato de serialización como camelCase.
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // solamente las propiedades se van a poner en camelCase, no los datos
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
