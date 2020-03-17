using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class AlcolholEnDrugsController
    {
        /// <summary>
        /// Delete a record from the Geslacht table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteGeslacht/{id}")]
        public HttpResponseMessage DeleteGeslacht(string id)
        {
            var item = db.ADGeslachts.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.ADGeslachts.Remove(item);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }


            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Delete a record from the Herkomst table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteHerkomst/{id}")]
        public HttpResponseMessage DeleteHerkomst(string id)
        {
            var item = db.ADHerkomsts.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.ADHerkomsts.Remove(item);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Delete a record from the Perioden table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeletePerioden/{id}")]
        public HttpResponseMessage DeletePerioden(string id)
        {
            var item = db.ADPeriodens.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.ADPeriodens.Remove(item);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Delete a record from the Geslacht table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteDataset/{id}")]
        public HttpResponseMessage DeleteDataset(int id)
        {
            var item = db.ADDataSets.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                db.ADDataSets.Remove(item);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}