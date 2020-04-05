using DataProcessingWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class AlcolholEnDrugsController
    {
        /// <summary>
        /// Gets the item by id
        /// </summary>
        /// <param name="id">the item to get</param>
        /// <returns>the item you want</returns>
        [HttpGet]
        public AlcoholEnDrugs Get(int id)
        {
            return db.ADDataSets.FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Get the data in a friendly readable format
        /// </summary>
        /// <param name="limit">the amount of items to get</param>
        /// <param name="skip">the amount of items to skip</param>
        /// <returns>a full list of AlcoholEnDrugs items</returns>
        [HttpGet, Route("Get/{limit?}/{skip?}")]
        public AlcoholEnDrugsDataSet Get(int limit = 100, int skip = 0)
        {
            var table = db.ADDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit);
            AlcoholEnDrugsDataSet lijstje = new AlcoholEnDrugsDataSet();
            foreach (var record in table)
            {
                lijstje.AlcoholEnDrugsArray.Add(record);
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
        /// Get Dataset Herkomst
        /// </summary>
        /// <param name="limit">items to get</param>
        /// <param name="skip">items to skip</param>
        /// <returns>list of items</returns>
        [HttpGet, Route("GetHerkomst/{limit?}/{skip?}")]
        public List<ADHerkomst> GetHerkomst(int limit = 100, int skip = 0)
        {
            return db.ADHerkomsts.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get Dataset Geslacht
        /// </summary>
        /// <param name="limit">items to get</param>
        /// <param name="skip">items to skip</param>
        /// <returns>list of items</returns>
        [HttpGet, Route("GetGeslacht/{limit?}/{skip?}")]
        public List<ADGeslacht> GetGeslacht(int limit = 100, int skip = 0)
        {
            return db.ADGeslachts.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get Dataset Perioden
        /// </summary>
        /// <param name="limit">items to get</param>
        /// <param name="skip">items to skip</param>
        /// <returns>list of items</returns>
        [HttpGet, Route("GetPerioden/{limit?}/{skip?}")]
        public List<ADPerioden> GetPerioden(int limit = 100, int skip = 0)
        {
            return db.ADPeriodens.OrderBy(n => n.Key).Skip(skip).Take(limit).ToList();
        }

        /// <summary>
        /// Get Dataset
        /// </summary>
        /// <param name="limit">items to get</param>
        /// <param name="skip">items to skip</param>
        /// <returns>list of items</returns>
        [HttpGet, Route("GetDataSet/{limit?}/{skip?}")]
        public List<ADDataSet> GetDataSet(int limit = 100, int skip = 0)
        {
            return db.ADDataSets.OrderBy(n => n.Id).Skip(skip).Take(limit).ToList();
        }

    }
}