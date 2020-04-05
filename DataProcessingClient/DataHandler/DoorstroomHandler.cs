using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class DoorstroomHandler : DataHandler<DoorstroomModel>
    {
        private List<DoorstroomModel> data;
        protected internal int Count { get => data.Count; }
        public DoorstroomHandler(string BaseUrl, DataFormat format, int max) : base(BaseUrl, format, max)
        {
            data = new List<DoorstroomModel>();
        }

        public override List<DoorstroomModel> GetData()
        {
            if (data.Count == 0)
            {
                List<DoorstroomModel> _data = DownloadData($"api/Doorstroom/Get/{MaxRecords}");
                SetData(_data);
                return _data;
            }
            else
            {
                return data;
            }
        }

        internal override List<DoorstroomModel> DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToDS(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<DoorstroomModel>>(response.Content);
            }
        }

        internal override async Task<List<DoorstroomModel>> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/Doorstroom/Get/{MaxRecords}", Format);
            switch (Format)
            {
                case DataFormat.XML:
                    return RestHelper.ConvertXMLToDS(response.Content);
                case DataFormat.JSON:
                default:
                    return RestHelper.ConvertJsonToObject<List<DoorstroomModel>>(response.Content);
            }
        }

        internal override void SetData(List<DoorstroomModel> data)
        {
            this.data = data;
        }
    }
}
