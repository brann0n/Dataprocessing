using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataProcessingWebAPI.Controllers
{
    /// <summary>
    /// Controler for the main part of the UI
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Only accessable page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
