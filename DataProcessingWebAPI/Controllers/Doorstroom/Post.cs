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
    public partial class DoorstroomController
    {
        /// <summary>
        /// Function to add a new record to the underlying Perioden dataset using validation
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostPerioden")]
        public async Task<HttpResponseMessage> PostPerioden(DSPerioden model)
        {
            bool validated = await ValidateAgainstSchemeAsync("DSPerioden");
            if (model != null && validated)
            {
                db.DSPeriodens.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying Kenmerken dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostGeslacht")]
        public HttpResponseMessage PostGeslacht(DSGeslacht model)
        {
            if (model != null)
            {
                db.DSGeslachts.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying MboLeerwegEnNiveau dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostMboLeerwegEnNiveau")]
        public HttpResponseMessage PostMboLeerwegEnNiveau(DSMboLeerwegEnNiveau model)
        {
            if (model != null)
            {
                db.DSMboLeerwegEnNiveaux.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying MboRichtingEnSector dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostMboRichtingEnSector")]
        public HttpResponseMessage PostMboRichtingEnSector(DSMboRichtingEnSector model)
        {
            if (model != null)
            {
                db.DSMboRichtingEnSectors.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying PersoonsKenmerken dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostPersoonsKenmerken")]
        public HttpResponseMessage PostPersoonsKenmerken(DSPersoonsKenmerken model)
        {
            if (model != null)
            {
                db.DSPersoonsKenmerkens.AddOrUpdate(model);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Response(HttpStatusCode.BadRequest, "Incorrect data was provided");
            }
        }

        /// <summary>
        /// Function to add a new record to the underlying Dataset dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPost, Route("PostDataset")]
        public HttpResponseMessage PostDataset(DSDataSet model)
        {
            if (model != null)
            {
                db.DSDataSets.AddOrUpdate(model);
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