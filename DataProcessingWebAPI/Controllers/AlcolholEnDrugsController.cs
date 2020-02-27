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
    public class AlcolholEnDrugsController : ApiController
    {
        //reference to the EntityFramework classes that are connected to the database
        DataProcessingEntities db = new DataProcessingEntities();

        /// <summary>
        /// Gets all the records in the AlcoholEnDrugs database
        /// </summary>
        /// <returns>a list of Alcohol En Drugs items</returns>
        public List<AlcoholEnDrugs> Get()
        {
            var table = db.ADDataSets;
            List<AlcoholEnDrugs> lijstje = new List<AlcoholEnDrugs>();
            foreach(var record in table)
            {
                lijstje.Add(record);
            }

            return lijstje;
        }

        /// <summary>
        /// Gets the specified amount of records from the database
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <returns>a full list</returns>
        [Route("GetPerLimit/{limit}")]
        public List<AlcoholEnDrugs> Get(int limit)
        {
            var table = db.ADDataSets.Take(limit);
            List<AlcoholEnDrugs> lijstje = new List<AlcoholEnDrugs>();
            foreach (var record in table)
            {
                lijstje.Add(record);
            }

            return lijstje;
        }

        /// <summary>
        /// Function to modify the underlying dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeHerkomst")]
        public HttpResponseMessage PostHerkomst(ADHerkomst model)
        {
            if(model != null)
            {
                db.ADHerkomsts.AddOrUpdate(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangePerioden")]
        public HttpResponseMessage PostPerioden(ADPerioden model)
        {
            if (model != null)
            {
                db.ADPeriodens.AddOrUpdate(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying dataset
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeGeslacht")]
        public HttpResponseMessage PostPerioden(ADGeslacht model)
        {
            if (model != null)
            {
                db.ADGeslachts.AddOrUpdate(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Function to modify the underlying dataset
        /// </summary>
        /// <param name="model">the changed model with keys to other tables</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [Route("ChangeGeslacht")]
        public HttpResponseMessage PostPerioden(ADDataSet model)
        {
            if (model != null)
            {
                db.ADDataSets.AddOrUpdate(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
