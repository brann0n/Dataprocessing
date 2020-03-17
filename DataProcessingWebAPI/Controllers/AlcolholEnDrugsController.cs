using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    /// <summary>
    /// The alcohol and drugs controller, this controller can do REST functions on the tables for Alcohol En Drugs
    /// </summary>
    [RoutePrefix("api/AlcoholEnDrugs")]
    public partial class AlcolholEnDrugsController : ApiController
    {
        //reference to the EntityFramework classes that are connected to the database
        DataProcessingEntities db = new DataProcessingEntities();

        /// <summary>
        /// Function to modify the underlying Herkomst dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeHerkomst")]
        public HttpResponseMessage PostHerkomst(ADHerkomst model)
        {
            if(model != null)
            {
                db.ADHerkomsts.AddOrUpdate(model);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying Perioden dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangePerioden")]
        public HttpResponseMessage PostPerioden(ADPerioden model)
        {
            if (model != null)
            {
                db.ADPeriodens.AddOrUpdate(model);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying Geslacht dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeGeslacht")]
        public HttpResponseMessage PostGeslacht(ADGeslacht model)
        {
            if (model != null)
            {
                db.ADGeslachts.AddOrUpdate(model);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying dataset
        /// </summary>
        /// <param name="model">the changed model with keys to other tables</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeDataset")]
        public HttpResponseMessage PostDataset(ADDataSet model)
        {
            if (model != null)
            {
                db.ADDataSets.AddOrUpdate(model);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
