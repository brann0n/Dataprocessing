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



        public static string ConvertObjectToXML<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static List<AlcoholEnDrugs> ConvertXMLToAD(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(ArrayOfAlcoholEnDrugs));
                MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                ArrayOfAlcoholEnDrugs DeserializedXMLObject = (ArrayOfAlcoholEnDrugs)xmlserializer.Deserialize(memStream);
                List<AlcoholEnDrugs> returnArray = new List<AlcoholEnDrugs>();
                foreach (ArrayOfAlcoholEnDrugsAlcoholEnDrugs item in DeserializedXMLObject.GetArray())
                {
                    returnArray.Add(item);
                }
                return returnArray;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        public static List<DoorstroomModel> ConvertXMLToDS(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(ArrayOfDoorstroomData));
                MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                ArrayOfDoorstroomData DeserializedXMLObject = (ArrayOfDoorstroomData)xmlserializer.Deserialize(memStream);
                List<DoorstroomModel> returnArray = new List<DoorstroomModel>();
                foreach (ArrayOfDoorstroomDataDoorstroomData item in DeserializedXMLObject.GetArray())
                {
                    returnArray.Add(item);
                }
                return returnArray;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        public static List<WerkzameBeroepsBevolkingModel> ConvertXMLToWB(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(ArrayOfWerkzameBeroepsbevolking));
                MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                ArrayOfWerkzameBeroepsbevolking DeserializedXMLObject = (ArrayOfWerkzameBeroepsbevolking)xmlserializer.Deserialize(memStream);
                List<WerkzameBeroepsBevolkingModel> returnArray = new List<WerkzameBeroepsBevolkingModel>();
                foreach (ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking item in DeserializedXMLObject.GetArray())
                {
                    returnArray.Add(item);
                }
                return returnArray;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
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
