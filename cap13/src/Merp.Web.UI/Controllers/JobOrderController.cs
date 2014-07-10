using Merp.Web.UI.Models.JobOrder;
using Merp.Web.UI.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merp.Web.UI.Controllers
{
    public class JobOrderController : Controller
    {
        public JobOrderControllerWorkerServices WorkerServices { get; private set; }

        public JobOrderController(JobOrderControllerWorkerServices workerServices)
        {
            if(workerServices==null)
            {
                throw new ArgumentNullException("workerServices");
            }
            WorkerServices = workerServices;
        }

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

        [HttpPost]
        public ActionResult CreateFixedPrice(CreateFixedPriceViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.CreateFixedPriceJobOrder(model);
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Extend()
        {
            var model = new ExtendViewModel();
            return View(model);
        }
    }
}