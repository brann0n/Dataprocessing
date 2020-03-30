﻿using Newtonsoft.Json.Linq;
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
    /// This controller inherits the ApiController class with some extra custom functions
    /// </summary>
    public abstract class DataController : ApiController
    {
        /// <summary>
        /// Checks the given schema agains the current raw data
        /// </summary>
        /// <param name="SchemeName">Name of the local scheme</param>
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
                throw new InvalidDataException("This API only accepts application/xml and application/json");
            }
        }

        private bool ValidateXML(string SchemaName, string Data)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("http://schemas.datacontract.org/2004/07/DataProcessingWebAPI", GetSchemaPath(SchemaName, ".xsd"));

            XDocument doc = XDocument.Parse(Data);

            bool errorInValidation = false;       
            doc.Validate(schema, (s, e) => {
                errorInValidation = true;
            });


            return !errorInValidation;
        }

        private bool ValidateJson(string SchemaName, string Data)
        {
            WebClient client = new WebClient();
            JObject obj = JObject.Parse(Data);
            JSchema schema = JSchema.Parse(client.DownloadString(GetSchemaPath(SchemaName, ".json")));
            bool errorInValidation = false;
            obj.Validate(schema, (s, e) => {
                errorInValidation = true;
            });
            client.Dispose();
            return !errorInValidation;
        }

        private string GetSchemaPath(string schema, string fileExtension)
        {
            var request = HttpContext.Current.Request;
            string protocol = request.IsSecureConnection ? "https" : "http";
            string domain = request.Url.Port == 80 ? request.Url.Host : request.Url.Authority;

            return $"{protocol}://{domain}/Content/Schemas/{schema}{fileExtension}";
        }

        /// <summary>
        /// Creates a http response message with the provided string
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected HttpResponseMessage Response(HttpStatusCode status, string message)
        {
            var res = new HttpResponseMessage();
            res.StatusCode = status;
            res.Content = new StringContent(message);
            return res;
        }
    }
}
