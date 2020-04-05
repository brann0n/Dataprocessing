using DataProcessingClient.DataHandler;
using DataProcessingClient.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DataProcessingClient
{
    public static class RestHelper
    {

        public static IRestResponse PostJson(string baseUrl, string resourceUrl, string json)
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(resourceUrl, Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.RequestFormat = RestSharp.DataFormat.Json;
            return client.Execute(request);
        }
        public static IRestResponse Get(string baseUrl, string resourceUrl, DataHandler.DataFormat format)
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(resourceUrl, Method.GET);

            switch (format)
            {
                case DataHandler.DataFormat.XML:
                    request.AddHeader("Accept", "text/xml");
                    return client.Execute(request);

                case DataHandler.DataFormat.JSON:
                default:
                    request.AddHeader("Accept", "application/json");
                    return client.Execute(request);
            }
        }

        public async static Task<IRestResponse> GetAsync(string baseUrl, string resourceUrl, DataHandler.DataFormat format)
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(resourceUrl, Method.GET);

            switch (format)
            {
                case DataHandler.DataFormat.XML:
                    request.AddHeader("Accept", "text/xml");
                    return await client.ExecuteGetAsync(request);

                case DataHandler.DataFormat.JSON:
                default:
                    request.AddHeader("Accept", "application/json");
                    return await client.ExecuteGetAsync(request);
            }
        }

        public static AlcoholEnDrugsDataSet ConvertXMLToAD(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            var xmlserializer = new XmlSerializer(typeof(AlcoholEnDrugsDataSet));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            AlcoholEnDrugsDataSet DeserializedXMLObject = (AlcoholEnDrugsDataSet)xmlserializer.Deserialize(memStream);
            var validationErrors = Validator.ValidateXML(DeserializedXMLObject.SchemaLocation, xml);
            if (validationErrors.Count == 0)
            {
                return DeserializedXMLObject;
            }
            else
            {
                throw new Exception("AlcoholEnDrugsDataSet: Validation failed");
            }

        }
        public static DoorstroomDataDataSet ConvertXMLToDS(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            var xmlserializer = new XmlSerializer(typeof(DoorstroomDataDataSet));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var DeserializedXMLObject = (DoorstroomDataDataSet)xmlserializer.Deserialize(memStream);
            var validationErrors = Validator.ValidateXML(DeserializedXMLObject.SchemaLocation, xml);
            if (validationErrors.Count == 0)
            {
                return DeserializedXMLObject;
            }
            else
            {
                throw new Exception("DoorstroomDataDataSet: Validation failed");
            }
        }
        public static WerkzameBeroepsbevolkingDataSet ConvertXMLToWB(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            var xmlserializer = new XmlSerializer(typeof(WerkzameBeroepsbevolkingDataSet));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var DeserializedXMLObject = (WerkzameBeroepsbevolkingDataSet)xmlserializer.Deserialize(memStream);
            var validationErrors = Validator.ValidateXML(DeserializedXMLObject.SchemaLocation, xml);
            if (validationErrors.Count == 0)
            {
                return DeserializedXMLObject;
            }
            else
            {
                throw new Exception("WerkzameBeroepsbevolkingDataSet: Validation failed");
            }
        }

        public static string ConvertObjectToJson(object arg)
        {
            return JsonConvert.SerializeObject(arg);
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            if (json[0] == '<')
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
