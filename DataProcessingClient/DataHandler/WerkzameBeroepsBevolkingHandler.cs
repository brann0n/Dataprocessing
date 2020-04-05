using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class WerkzameBeroepsBevolkingHandler : DataHandler<WerkzameBeroepsBevolkingModel>
    {
        private List<WerkzameBeroepsBevolkingModel> data;
        protected internal int Count { get => data.Count; }
        public WerkzameBeroepsBevolkingHandler(string BaseUrl, DataFormat format, int max) : base(BaseUrl, format, max)
        {
            data = new List<WerkzameBeroepsBevolkingModel>();
        }

        public override List<WerkzameBeroepsBevolkingModel> GetData()
        {
            if (data.Count == 0)
            {
                List<WerkzameBeroepsBevolkingModel> _data = DownloadData($"api/WerkzameBeroepsbevolking/Get/{MaxRecords}");
                SetData(_data);
                return _data;
            }
            else
            {
                return data;
            }
        }

        internal override List<WerkzameBeroepsBevolkingModel> DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToWB(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<WerkzameBeroepsBevolkingModel>>(response.Content);
            }
        }

        internal override async Task<List<WerkzameBeroepsBevolkingModel>> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/WerkzameBeroepsbevolking/Get/{MaxRecords}", Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToWB(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<WerkzameBeroepsBevolkingModel>>(response.Content);
            }
        }

        internal override void SetData(List<WerkzameBeroepsBevolkingModel> data)
        {
            this.data = data;
        }
    }
}
