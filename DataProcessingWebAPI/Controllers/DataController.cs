using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DataProcessingWebAPI.Controllers
{
    /// <summary>
    /// simple enum for xml or json
    /// </summary>
    public enum DataFormat
    {
        /// <summary>
        /// XML
        /// </summary>
        XML = 0,
        /// <summary>
        /// JSON
        /// </summary>
        JSON = 1
    }
    /// <summary>
    /// This controller inherits the ApiController class with some extra custom functions
    /// </summary>
    [ApiExceptionHandler]
    public abstract class DataController : ApiController
    {
        /// <summary>
        /// Checks the given schema agains the current raw data
        /// </summary>
        /// <param name="SchemaName">Name of the local scheme</param>
        /// <returns>boolean that is true when data matches the scheme and false if it doesnt match</returns>
        protected async Task<bool> ValidateAgainstSchemeAsync(string SchemaName)
        {
            string data;
            string contentType;

            contentType = Request.Content.Headers.ContentType.MediaType;

            using (var contentStream = await Request.Content.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    data = sr.ReadToEnd();
                }
            }

            if (contentType == "application/xml")
            {
                return ValidateXML(SchemaName, data);
            }
            else if (contentType == "application/json")
            {
                return ValidateJson(SchemaName, data);
            }
            else
            {
                throw new ValidationException<string>("This API only accepts application/xml and application/json");
            }
        }

        /// <summary>
        /// Validates XML against a schema
        /// </summary>
        /// <param name="SchemaName"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        private bool ValidateXML(string SchemaName, string Data)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("http://schemas.datacontract.org/2004/07/DataProcessingWebAPI", GetSchemaPath(SchemaName, ".xsd"));

            XDocument doc = XDocument.Parse(Data);
            List<System.Xml.Schema.ValidationEventArgs> valErrors = new List<System.Xml.Schema.ValidationEventArgs>();     
            doc.Validate(schema, (s, e) => {
                valErrors.Add(e);
            });

            if(valErrors.Count != 0)
            {
                throw new ValidationException<System.Xml.Schema.ValidationEventArgs>("Errors while validating XML.", valErrors);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates json agains a schema
        /// </summary>
        /// <param name="SchemaName"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        private bool ValidateJson(string SchemaName, string Data)
        {
            WebClient client = new WebClient();
            JObject obj = JObject.Parse(Data);
            JSchema schema = JSchema.Parse(client.DownloadString(GetSchemaPath(SchemaName, ".json")));
            List<SchemaValidationEventArgs> valErrors = new List<SchemaValidationEventArgs>();
            obj.Validate(schema, (s, e) => {
                valErrors.Add(e);
            });

            client.Dispose();

            if (valErrors.Count != 0)
            {
                throw new ValidationException<SchemaValidationEventArgs>("Errors while validating JSON.", valErrors);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the path to your schema, relative to the webserver
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private string GetSchemaPath(string schema, string fileExtension)
        {
            var request = HttpContext.Current.Request;
            string protocol = request.IsSecureConnection ? "https" : "http";
            string domain = request.Url.Port == 80 ? request.Url.Host : request.Url.Authority;

            return $"{protocol}://{domain}/Content/Schemas/{schema}{fileExtension}";
        }

        /// <summary>
        /// Checks the accept header and then converts that into a simple enum
        /// </summary>
        /// <returns></returns>
        protected DataFormat GetAccept()
        {
            string key = "Accept";
            string value = "";
            if (Request.Headers.Contains(key))
            {
                value = Request.Headers.FirstOrDefault(n => n.Key == key).Value.FirstOrDefault();
                if (value == "application/xml")
                {
                    return DataFormat.XML;
                }
                else if (value == "application/json")
                {
                    return DataFormat.JSON;
                }
            }

            return DataFormat.JSON;
        }

        /// <summary>
        /// Creates a http response message with the provided string
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected HttpResponseMessage Response(HttpStatusCode status, string message)
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
