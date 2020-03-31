using System.Data.Entity.Migrations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    public partial class AlcolholEnDrugsController
    {
        /// <summary>
        /// Function to modify the underlying Herkomst dataset using validation
        /// </summary>
        /// <param name="model">the changed model</param>
        /// <returns>http response message with status code 200 or 500</returns>
        [HttpPut, Route("PutHerkomst")]
        public async Task<HttpResponseMessage> PutHerkomst(ADHerkomst model)
        {
            bool validated = await ValidateAgainstSchemeAsync("ADHerkomst");
            if (model != null && validated)
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
        [HttpPut, Route("PutPerioden")]
        public HttpResponseMessage PutPerioden(ADPerioden model)
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
        [HttpPut, Route("PutGeslacht")]
        public HttpResponseMessage PutGeslacht(ADGeslacht model)
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
        [HttpPut, Route("PutDataset")]
        public HttpResponseMessage PutDataset(ADDataSet model)
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