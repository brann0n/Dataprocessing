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
        /// <summary>
        /// The base url of the API
        /// </summary>
        protected internal string BaseURL { get; set; }

        /// <summary>
        /// The format in which to retrieve data
        /// </summary>
        protected internal DataFormat Format { get; set; }

        /// <summary>
        /// The maximum amount of records to retrieve from the API
        /// </summary>
        protected internal int MaxRecords { get; set; }

        public DataHandler(string BaseUrl, DataFormat format, int max)
        {
            this.BaseURL = BaseUrl;
            this.Format = format;
            MaxRecords = max;
        }

        /// <summary>
        /// Returns the data inside the object
        /// </summary>
        /// <returns></returns>
        public abstract T GetData();

        /// <summary>
        /// Sets the data inside the Object
        /// </summary>
        /// <param name="data">Your object</param>
        internal abstract void SetData(T data);

        /// <summary>
        /// Downloads data from the api with the provided URL
        /// </summary>
        /// <param name="resourceURL"></param>
        /// <returns></returns>
        internal abstract T DownloadData(string resourceURL);

        /// <summary>
        /// Can only download data from the internal url and does this Async
        /// </summary>
        /// <returns></returns>
        internal abstract Task<T> DownloadDataAsync();
    }
}
