using DataProcessingClient.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public class WerkzameBeroepsBevolkingHandler : DataHandler<WerkzameBeroepsbevolkingDataSet>
    {
        private WerkzameBeroepsbevolkingDataSet data;
        protected internal int Count { get => data?.WerkzameBeroepsbevolkingArray == null ? 0 : data.WerkzameBeroepsbevolkingArray.Length; }
        public WerkzameBeroepsBevolkingHandler(string BaseUrl, DataFormat format, int max) : base(BaseUrl, format, max)
        {
            data = new WerkzameBeroepsbevolkingDataSet();
        }

        public override WerkzameBeroepsbevolkingDataSet GetData()
        {
            if (data == null || Count == 0)
            {
                WerkzameBeroepsbevolkingDataSet _data = DownloadData($"api/WerkzameBeroepsbevolking/Get/{MaxRecords}");
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

        internal override WerkzameBeroepsbevolkingDataSet DownloadData(string resourceURL)
        {
            IRestResponse response = RestHelper.Get(this.BaseURL, resourceURL, Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToWB(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToWB(response.Content);
                }
            }
            catch
            {
                return null;
            }

        }

        internal override async Task<WerkzameBeroepsbevolkingDataSet> DownloadDataAsync()
        {
            IRestResponse response = await RestHelper.GetAsync(this.BaseURL, $"api/WerkzameBeroepsbevolking/Get/{MaxRecords}", Format);
            try
            {
                switch (Format)
                {
                    case DataFormat.XML:
                        return RestHelper.ConvertXMLToWB(response.Content);
                    case DataFormat.JSON:
                    default:
                        return RestHelper.ConvertJsonToWB(response.Content);
                }
            }
            catch (Exception e)
            {
                DataForm.ReportError(e);
                return null;
            }
        }

        internal override void SetData(WerkzameBeroepsbevolkingDataSet data)
        {
            this.data = data;
        }
    }
}
