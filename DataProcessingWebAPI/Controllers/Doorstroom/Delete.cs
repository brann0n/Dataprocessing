using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class DoorstroomController
    {
        /// <summary>
        /// Delete a record from the Geslacht table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteGeslacht/{id}")]
        public HttpResponseMessage DeleteGeslacht(string id)
        {
            var item = db.DSGeslachts.FirstOrDefault(n => n.Key == id);
            if(item != null)
            {
                db.DSGeslachts.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Title} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }

        /// <summary>
        /// Delete a record from the MboLeerwegEnNiveaus table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteMboLeerwegEnNiveaus/{id}")]
        public HttpResponseMessage DeleteMboLeerwegEnNiveaus(string id)
        {
            var item = db.DSMboLeerwegEnNiveaux.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.DSMboLeerwegEnNiveaux.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Title} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }

        /// <summary>
        /// Delete a record from the MboRichtingEnSectors table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteMboRichtingEnSectors/{id}")]
        public HttpResponseMessage DeleteMboRichtingEnSectors(string id)
        {
            var item = db.DSMboRichtingEnSectors.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.DSMboRichtingEnSectors.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Title} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }

        /// <summary>
        /// Delete a record from the Perioden table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeletePerioden/{id}")]
        public HttpResponseMessage DeletePerioden(string id)
        {
            var item = db.DSPeriodens.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.DSPeriodens.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Title} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }

        /// <summary>
        /// Delete a record from the PersoonsKenmerken table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeletePersoonsKenmerken/{id}")]
        public HttpResponseMessage DeletePersoonsKenmerken(string id)
        {
            var item = db.DSPersoonsKenmerkens.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.DSPersoonsKenmerkens.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Title} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }

        /// <summary>
        /// Delete a record from the Dataset table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteDataSet/{id}")]
        public HttpResponseMessage DeleteDataSet(int id)
        {
            var item = db.DSDataSets.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                db.DSDataSets.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Id} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }
    }
}