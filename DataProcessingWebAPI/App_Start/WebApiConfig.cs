using DataProcessingWebAPI.App_Start;
using DataProcessingWebAPI.Areas.HelpPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI
{
    /// <summary>
    /// This class takes care of the configuration for WebApi
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Function that registers a few http configuration properties
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new BrowserJsonFormatter());
            config.Formatters.Add(new XMLFormatter("http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models"));
            config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));
        }
    }
}
