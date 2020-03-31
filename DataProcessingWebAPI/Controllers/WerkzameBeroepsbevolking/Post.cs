using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class WerkzameBeroepsbevolkingController
    {
        /// <summary>
        /// Function to add a new record to the underlying Perioden dataset using validation
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostPerioden")]
        public async Task<HttpResponseMessage> PostPerioden(WBPerioden model)
        {
            bool validated = await ValidateAgainstSchemeAsync("WBPerioden");
            if (model != null && validated)
            {
                db.WBPeriodens.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided and validation failed.");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying Kenmerken dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostKenmerken")]
        public HttpResponseMessage PostKenmerken(WBKenmerken model)
        {
            if (model != null)
            {
                db.WBKenmerkens.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying Dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostDataset")]
        public HttpResponseMessage PostDataset(WBDataSet model)
        {
            if (model != null)
            {
                db.WBDataSets.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }
    }
}