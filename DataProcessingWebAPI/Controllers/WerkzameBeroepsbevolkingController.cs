using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    /// <summary>
    /// The WerkzameBeroepsbevolking controller, this controller can do REST functions on the WerkzameBeroepsbevolking tables.
    /// </summary>
    [RoutePrefix("api/WerkzameBeroepsbevolking")]
    public partial class WerkzameBeroepsbevolkingController : DataController
    {
        //reference to the EntityFramework classes that are connected to the database
        DataProcessingEntities db = new DataProcessingEntities();
    }
}
