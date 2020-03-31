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
        /// Function to modify the underlying Perioden dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [HttpPut, Route("PutPerioden")]
        public async Task<HttpResponseMessage> PutPerioden(WBPerioden model)
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
        /// Function to modify the underlying Kenmerken dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutKenmerken")]
        public HttpResponseMessage PutKenmerken(WBKenmerken model)
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
        /// Function to modify the underlying Dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutDataset")]
        public HttpResponseMessage PutDataset(WBDataSet model)
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