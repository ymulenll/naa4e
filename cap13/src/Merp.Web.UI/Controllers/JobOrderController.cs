using Merp.Web.UI.Models.JobOrder;
using Merp.Web.UI.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;

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
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
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
            return Redirect("/JobOrder");
        }

        [HttpGet]
        public ActionResult CreateTimeAndMaterial()
        {
            var model = new CreateTimeAndMaterialViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTimeAndMaterial(CreateTimeAndMaterialViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.CreateTimeAndMaterialJobOrder(model);
            return Redirect("/JobOrder");
        }

        [HttpGet]
        public ActionResult Extend()
        {
            var model = new ExtendViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Extend(ExtendViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.ExtendJobOrder(model);
            return Redirect("/JobOrder");
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var model = WorkerServices.GetList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}