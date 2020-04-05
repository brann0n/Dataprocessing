using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class AlcoholEnDrugsHandler : DataHandler<AlcoholEnDrugs>
    {
        private List<AlcoholEnDrugs> data;
        protected internal int Count { get => data.Count; }
        public AlcoholEnDrugsHandler(string baseUrl, DataFormat format, int max) : base(baseUrl, format, max)
        {
            data = new List<AlcoholEnDrugs>();
        }

        internal override List<AlcoholEnDrugs> DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToAD(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<AlcoholEnDrugs>>(response.Content);
            }
        }

        public override List<AlcoholEnDrugs> GetData()
        {
            if (data.Count == 0)
            {
                List<AlcoholEnDrugs> _data = DownloadData($"api/AlcoholEnDrugs/Get/{MaxRecords}");
                SetData(_data);
                return _data;
            }
            else
            {
                return data;
            }
        }

        internal override void SetData(List<AlcoholEnDrugs> data)
        {
            this.data = data;
        }

        internal override async Task<List<AlcoholEnDrugs>> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/AlcoholEnDrugs/Get/{MaxRecords}", Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToAD(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<AlcoholEnDrugs>>(response.Content);
            }
        }
    }
}
