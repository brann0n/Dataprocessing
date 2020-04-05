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
        /// Gets the item by id
        /// </summary>
        /// <param name="id">the item to get</param>
        /// <returns>the item you want</returns>
        [HttpGet]
        public DoorstroomData Get(int id)
        {
            return db.DSDataSets.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Doorstroom items</returns>
        [HttpGet, Route("Get/{limit?}/{skip?}")]
        public DoorstroomDataDataSet Get(int limit = 100, int skip = 0)
        {
            var table = db.DSDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit);
            DoorstroomDataDataSet lijstje = new DoorstroomDataDataSet();
            foreach (var record in table)
            {
                lijstje.DoorstroomDataArray.Add(record);
            }

            switch (GetAccept())
            {
                case DataFormat.XML:
                    lijstje.SchemaLocation += ".xsd";
                    break;
                case DataFormat.JSON:
                    lijstje.SchemaLocation += ".json";
                    break;
            }

            return lijstje;
        }

        /// <summary>
        /// Get Geslacht Dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Geslacht items</returns>
        [HttpGet, Route("GetGeslacht/{limit?}/{skip?}")]
        public List<DSGeslacht> GetGeslacht(int limit = 100, int skip = 0)
        {
            return db.DSGeslachts.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get MboLeerwegEnNiveaus Dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of MboLeerwegEnNiveaus items</returns>
        [HttpGet, Route("GetMboLeerwegEnNiveaus/{limit?}/{skip?}")]
        public List<DSMboLeerwegEnNiveau> GetMboLeerwegEnNiveaus(int limit = 100, int skip = 0)
        {
            return db.DSMboLeerwegEnNiveaux.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get MboRichtingEnSectors Dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of MboRichtingEnSectors items</returns>
        [HttpGet, Route("GetMboRichtingEnSectors/{limit?}/{skip?}")]
        public List<DSMboRichtingEnSector> GetMboRichtingEnSectors(int limit = 100, int skip = 0)
        {
            return db.DSMboRichtingEnSectors.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get Perioden dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Perioden items</returns>
        [HttpGet, Route("GetPerioden/{limit?}/{skip?}")]
        public List<DSPerioden> GetPerioden(int limit = 100, int skip = 0)
        {
            return db.DSPeriodens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get Persoonskenmerken dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of PersoonsKenmerken items</returns>
        [HttpGet, Route("GetPersoonsKenmerken/{limit?}/{skip?}")]
        public List<DSPersoonsKenmerken> GetPersoonsKenmerken(int limit = 100, int skip = 0)
        {
            return db.DSPersoonsKenmerkens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get the actual dataset
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of Dataset items</returns>
        [HttpGet, Route("GetDataSet/{limit?}/{skip?}")]
        public List<DSDataSet> GetDataSet(int limit = 100, int skip = 0)
        {
            return db.DSDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit).ToList();
        }
    }
}