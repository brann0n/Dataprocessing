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
        /// Function to modify the underlying Perioden dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [HttpPut, Route("PutPerioden")]
        public async Task<HttpResponseMessage> PutPerioden(DSPerioden model)
        {
            bool validated = await ValidateAgainstSchemeAsync("WBPerioden");
            if (model != null && validated)
            {
                db.DSPeriodens.AddOrUpdate(model);
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
        [HttpPut, Route("PutGeslacht")]
        public HttpResponseMessage PutGeslacht(DSGeslacht model)
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
        /// Function to modify the underlying MboLeerwegEnNiveau dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutMboLeerwegEnNiveau")]
        public HttpResponseMessage PutMboLeerwegEnNiveau(DSMboLeerwegEnNiveau model)
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
        /// Function to modify the underlying MboRichtingEnSector dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutMboRichtingEnSector")]
        public HttpResponseMessage PutMboRichtingEnSector(DSMboRichtingEnSector model)
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
        /// Function to modify the underlying PersoonsKenmerken dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutPersoonsKenmerken")]
        public HttpResponseMessage PutPersoonsKenmerken(DSPersoonsKenmerken model)
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
        /// Function to modify the underlying Dataset dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 400</returns>
        [HttpPut, Route("PutDataset")]
        public HttpResponseMessage PutDataset(DSDataSet model)
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