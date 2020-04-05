using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class AlcoholEnDrugsHandler : DataHandler<AlcoholEnDrugsDataSet>
    {
        private AlcoholEnDrugsDataSet data;
        protected internal int Count { get => data?.AlcoholEnDrugsArray == null ? 0 : data.AlcoholEnDrugsArray.Length; }
        public AlcoholEnDrugsHandler(string baseUrl, DataFormat format, int max) : base(baseUrl, format, max)
        {
            data = new AlcoholEnDrugsDataSet();
        }

        internal override AlcoholEnDrugsDataSet DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToAD(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToAD(response.Content);
                }
            }
            catch
            {
                return null;
            }
        }

        public override AlcoholEnDrugsDataSet GetData()
        {
            if (data == null || Count == 0)
            {
                AlcoholEnDrugsDataSet _data = DownloadData($"api/AlcoholEnDrugs/Get/{MaxRecords}");
                if(_data != null)
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

        internal override void SetData(AlcoholEnDrugsDataSet data)
        {
            this.data = data;
        }

        internal override async Task<AlcoholEnDrugsDataSet> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/AlcoholEnDrugs/Get/{MaxRecords}", Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToAD(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToAD(response.Content);
                }
            }
            catch (Exception e)
            {
                DataForm.ReportError(e);
                return null;
            }
            
        }
    }
}
