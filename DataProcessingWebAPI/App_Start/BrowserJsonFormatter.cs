using Newtonsoft.Json;
using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace DataProcessingWebAPI.App_Start
{
    /// <summary>
    /// Formatter for json in the browser
    /// </summary>
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {

        /// <summary>
        /// Constructor that specifies that the formatter may only react to text/html
        /// also makes indentation possible
        /// </summary>
        public BrowserJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Sets content headers
        /// </summary>
        /// <param name="type"></param>
        /// <param name="headers"></param>
        /// <param name="mediaType"></param>
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}