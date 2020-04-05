using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient.DataHandler
{
    public enum DataFormat
    {
        XML = 0,
        JSON = 1
    }

    public abstract class DataHandler<T>
    {
        protected internal string BaseURL { get; set; }
        protected internal DataFormat Format { get; set; }
        protected internal int MaxRecords { get; set; }

        public DataHandler(string BaseUrl, DataFormat format, int max)
        {
            this.BaseURL = BaseUrl;
            this.Format = format;
            MaxRecords = max;
        }

        public abstract List<T> GetData();

        internal abstract void SetData(List<T> data);
        internal abstract List<T> DownloadData(string resourceURL);
        internal abstract Task<List<T>> DownloadDataAsync();
    }
}
