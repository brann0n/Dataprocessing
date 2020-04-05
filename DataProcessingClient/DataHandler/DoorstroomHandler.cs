using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class DoorstroomHandler : DataHandler<DoorstroomDataDataSet>
    {
        private DoorstroomDataDataSet data;
        protected internal int Count { get => data?.DoorstroomDataArray == null ? 0 : data.DoorstroomDataArray.Length; }
        public DoorstroomHandler(string BaseUrl, DataFormat format, int max) : base(BaseUrl, format, max)
        {
            data = new DoorstroomDataDataSet();
        }

        public override DoorstroomDataDataSet GetData()
        {
            if (data == null || Count == 0)
            {
                DoorstroomDataDataSet _data = DownloadData($"api/Doorstroom/Get/{MaxRecords}");
                if (_data != null)
                {
                    SetData(_data);
                    return _data;
                }
                else
                {
                    return data;
                }
            }
            else
            {
                return data;
            }
        }

        internal override DoorstroomDataDataSet DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToDS(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToDS(response.Content);
                }
            }
            catch
            {
                return null;
            }
        }

        internal override async Task<DoorstroomDataDataSet> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/Doorstroom/Get/{MaxRecords}", Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToDS(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToDS(response.Content);
                }
            }
            catch (Exception e)
            {
                DataForm.ReportError(e);
                return null;
            }            
        }

        internal override void SetData(DoorstroomDataDataSet data)
        {
            this.data = data;
        }
    }
}
