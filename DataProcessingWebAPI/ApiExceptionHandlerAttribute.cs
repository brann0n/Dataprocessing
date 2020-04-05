using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Xml;
using System.Xml.Schema;

namespace DataProcessingWebAPI
{
    /// <summary>
    /// Attribute that handles any exception that occures on the api controllers
    /// </summary>
    public class ApiExceptionHandlerAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// Invoked when an exception occures
        /// </summary>
        /// <param name="c">contains the context of the exception</param>
        public override void OnException(HttpActionExecutedContext c)
        {
            if (c.Exception is NotImplementedException)
            {
                c.Response = Response(HttpStatusCode.NotImplemented, "This resource was not yet implemented.");
            }
            else if (c.Exception is XmlException)
            {
                c.Response = Response(HttpStatusCode.BadRequest, $"Your xml contains syntax errors. Info: {c.Exception.Message}");
            }
            else if (c.Exception is ValidationException<string>)
            {
                ValidationException<string> ex = (ValidationException<string>)c.Exception;

                c.Response = Response(HttpStatusCode.Forbidden, ex.Message);
            }
            else if (c.Exception is ValidationException<System.Xml.Schema.ValidationEventArgs>)
            {
                string Message = "Validation errors found: \r\n";
                ValidationException<System.Xml.Schema.ValidationEventArgs> ex =
                    (ValidationException<System.Xml.Schema.ValidationEventArgs>)c.Exception;
                foreach (var item in ex.Exceptions)
                {
                    Message += $"{item.Message}\r\n";
                }
                c.Response = Response(HttpStatusCode.Forbidden, Message);
            }
            else if (c.Exception is ValidationException<SchemaValidationEventArgs>)
            {
                string Message = "Validation errors found: \r\n";
                ValidationException<SchemaValidationEventArgs> ex =
                    (ValidationException<SchemaValidationEventArgs>)c.Exception;
                foreach(var item in ex.Exceptions)
                {
                    Message += $"{item.Message}\r\n";
                }

                c.Response = Response(HttpStatusCode.Forbidden, Message);
            }
            else if (c.Exception is HttpResponseException)
            {
                HttpResponseException e = (HttpResponseException)c.Exception;

                if(e.Response.StatusCode == HttpStatusCode.UnsupportedMediaType)
                {
                    c.Response = Response(e.Response.StatusCode, "This API only accepts application/xml and application/json");
                }
                else
                {
                    c.Response = Response(e.Response.StatusCode, e.Message);
                }              
            }
            else
            {
                c.Response = Response(HttpStatusCode.InternalServerError, $"An unexpected error occured on the server. \r\nProvided error message: {c.Exception.Message}");
            }
        }

        /// <summary>
        /// Creates a http response message with the provided string
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private HttpResponseMessage Response(HttpStatusCode status, string message)
        {
            HttpResponseMessage res = new HttpResponseMessage
            {
                StatusCode = status,
                Content = new StringContent(message)
            };
            return res;
        }
    }
}