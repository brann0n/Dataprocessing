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
    /// The doorstroom controller, this controller can do REST functions on the Doorstroom tables.
    /// </summary>
    [RoutePrefix("api/Doorstroom")]
    public partial class DoorstroomController : ApiController
    {
        //reference to the EntityFramework classes that are connected to the database
        DataProcessingEntities db = new DataProcessingEntities();

       
    }
}
