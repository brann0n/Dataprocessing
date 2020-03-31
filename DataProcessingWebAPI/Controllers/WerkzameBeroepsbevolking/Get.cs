using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class WerkzameBeroepsbevolkingController
    {
        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of WerkzameBeroepsbevolking items</returns>
        [HttpGet, Route("Get/{limit?}/{skip?}")]
        public List<WerkzameBeroepsbevolking> Get(int limit = 100, int skip = 0)
        {
            var table = db.WBDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit);
            List<WerkzameBeroepsbevolking> lijstje = new List<WerkzameBeroepsbevolking>();
            foreach (var record in table)
            {
                lijstje.Add(record);
            }

            return lijstje;
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Kenmerken items</returns>
        [HttpGet, Route("GetKenmerken/{limit?}/{skip?}")]
        public List<WBKenmerken> GetKenmerken(int limit = 100, int skip = 0)
        {
            return db.WBKenmerkens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Perioden items</returns>
        [HttpGet, Route("GetPerioden/{limit?}/{skip?}")]
        public List<WBPerioden> GetPerioden(int limit = 100, int skip = 0)
        {
            return db.WBPeriodens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Dataset items</returns>
        [HttpGet, Route("GetDataSet/{limit?}/{skip?}")]
        public List<WBDataSet> GetDataSet(int limit = 100, int skip = 0)
        {
            return db.WBDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit).ToList();
        }
    }
}