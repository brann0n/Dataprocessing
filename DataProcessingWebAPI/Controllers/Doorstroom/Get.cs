using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class DoorstroomController
    {
        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Doorstroom items</returns>
        [Route("Get/{limit?}/{skip?}")]
        public List<DoorstroomData> Get(int limit = 100, int skip = 0)
        {
            var table = db.DSDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit);
            List<DoorstroomData> lijstje = new List<DoorstroomData>();
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
        /// <returns>a full list of Geslacht items</returns>
        [Route("GetGeslacht/{limit?}/{skip?}")]
        public List<DSGeslacht> GetGeslacht(int limit = 100, int skip = 0)
        {
            return db.DSGeslachts.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of MboLeerwegEnNiveaus items</returns>
        [Route("GetMboLeerwegEnNiveaus/{limit?}/{skip?}")]
        public List<DSMboLeerwegEnNiveau> GetMboLeerwegEnNiveaus(int limit = 100, int skip = 0)
        {
            return db.DSMboLeerwegEnNiveaux.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of MboRichtingEnSectors items</returns>
        [Route("GetMboRichtingEnSectors/{limit?}/{skip?}")]
        public List<DSMboRichtingEnSector> GetMboRichtingEnSectors(int limit = 100, int skip = 0)
        {
            return db.DSMboRichtingEnSectors.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Perioden items</returns>
        [Route("GetPerioden/{limit?}/{skip?}")]
        public List<DSPerioden> GetPerioden(int limit = 100, int skip = 0)
        {
            return db.DSPeriodens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of PersoonsKenmerken items</returns>
        [Route("GetPersoonsKenmerken/{limit?}/{skip?}")]
        public List<DSPersoonsKenmerken> GetPersoonsKenmerken(int limit = 100, int skip = 0)
        {
            return db.DSPersoonsKenmerkens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Dataset items</returns>
        [Route("GetDataSet/{limit?}/{skip?}")]
        public List<DSDataSet> GetDataSet(int limit = 100, int skip = 0)
        {
            return db.DSDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit).ToList();
        }
    }
}