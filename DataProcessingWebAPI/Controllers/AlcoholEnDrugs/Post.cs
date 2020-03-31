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
    public partial class AlcolholEnDrugsController
    {
        /// <summary>
        /// Function to add a new record to the underlying Herkomst dataset using validation
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost]
        [Route("PostHerkomst")]
        public async Task<HttpResponseMessage> PostHerkomst(ADHerkomst model)
        {
            bool validated = await ValidateAgainstSchemeAsync("ADHerkomst");
            if (model != null && validated)
            {
                db.ADHerkomsts.AddOrUpdate(model);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Could not validate request");
            }
            
        }

        /// <summary>
        /// Function to add a new record to the underlying Perioden dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost]
        [Route("PostPerioden")]
        public HttpResponseMessage PostPerioden(ADPerioden model)
        {
            if (model != null)
            {
                db.ADPeriodens.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying Geslacht dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost]
        [Route("PostGeslacht")]
        public HttpResponseMessage PostGeslacht(ADGeslacht model)
        {
            if (model != null)
            {
                db.ADGeslachts.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying dataset
        /// </summary>
        /// <param name="model">the changed model with keys to other tables</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost]
        [Route("PostDataset")]
        public HttpResponseMessage PostDataset(ADDataSet model)
        {
            if (model != null)
            {
                db.ADDataSets.AddOrUpdate(model);
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