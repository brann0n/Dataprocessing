using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DataProcessingClient
{
    class Validator
    {
        public static List<System.Xml.Schema.ValidationEventArgs> ValidateXML(string SchemaPath, string Data)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("http://schemas.datacontract.org/2004/07/DataProcessingWebAPI.Models", SchemaPath);

            XDocument doc = XDocument.Parse(Data);
            List<System.Xml.Schema.ValidationEventArgs> valErrors = new List<System.Xml.Schema.ValidationEventArgs>();
            doc.Validate(schema, (s, e) => {
                valErrors.Add(e);
            });        
            return valErrors;           
        }

        public static List<SchemaValidationEventArgs> ValidateJson(string SchemaPath, string Data)
        {
            WebClient client = new WebClient();
            JObject obj = JObject.Parse(Data);
            JSchema schema = JSchema.Parse(client.DownloadString(SchemaPath));
            List<SchemaValidationEventArgs> valErrors = new List<SchemaValidationEventArgs>();
            obj.Validate(schema, (s, e) => {
                valErrors.Add(e);
            });

            client.Dispose();

            if (valErrors.Count != 0)
            {
                return valErrors;
            }
            else
            {
                return default;
            }
        }
    }
}
