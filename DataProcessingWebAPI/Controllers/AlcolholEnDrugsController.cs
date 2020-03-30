using DataProcessingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataProcessingWebAPI.Controllers
{
    /// <summary>
    /// The alcohol and drugs controller, this controller can do REST functions on the tables for Alcohol En Drugs
    /// </summary>
    [RoutePrefix("api/AlcoholEnDrugs")]
    public partial class AlcolholEnDrugsController : DataController
    {
        //reference to the EntityFramework classes that are connected to the database
        DataProcessingEntities db = new DataProcessingEntities();          
    }
}
