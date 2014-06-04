using Merp.Web.UI.Models.JobOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merp.Web.UI.Controllers
{
    public class JobOrderController : Controller
    {
        // GET: JobOrder
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateFixedPrice()
        {
            var model = new CreateFixedPriceViewModel();
            return View(model);
        }
    }
}