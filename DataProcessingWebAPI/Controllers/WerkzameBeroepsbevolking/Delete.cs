using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class WerkzameBeroepsbevolkingController
    {
        /// <summary>
        /// Delete a record from the Kenmerken table
        /// </summary>
        /// <param name="id">key of the delete item</param>
        /// <returns>200 or 404</returns>
        [HttpDelete, Route("DeleteKenmerken/{id}")]
        public HttpResponseMessage DeleteKenmerken(string id)
        {
            var item = db.WBKenmerkens.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.WBKenmerkens.Remove(item);
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
            var item = db.WBPeriodens.FirstOrDefault(n => n.Key == id);
            if (item != null)
            {
                db.WBPeriodens.Remove(item);
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
        [HttpDelete, Route("DeleteDataset/{id}")]
        public HttpResponseMessage DeleteDataset(int id)
        {
            var item = db.WBDataSets.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                db.WBDataSets.Remove(item);
                db.SaveChanges();
                return Response(HttpStatusCode.OK, $"item {item.Id} was removed");
            }
            return Response(HttpStatusCode.NotFound, $"Item with id {id} was not found!");
        }
    }
}