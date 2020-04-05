using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace DataProcessingWebAPI.App_Start
{
    public class XMLFormatter : XmlMediaTypeFormatter
    {
        private readonly string defaultRootNamespace;
        public XMLFormatter() :this(string.Empty)
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            this.UseXmlSerializer = true;
        }

        public XMLFormatter(string defaultNS)
        {
            defaultRootNamespace = defaultNS;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/xml");
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            try
            {
                XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(type.Name)
                {
                    Namespace = defaultRootNamespace
                };

                var xns = new XmlSerializerNamespaces();            
                xns.Add("", defaultRootNamespace);
                xns.Add("i", "http://www.w3.org/2001/XMLSchema-instance");


                var task = Task.Factory.StartNew(() =>
                {
                    var serializer = new XmlSerializer(type, xmlRootAttribute);                   
                    serializer.Serialize(writeStream, value, xns);
                });
                return task;
            }
            catch (Exception)
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
        }
    }
}