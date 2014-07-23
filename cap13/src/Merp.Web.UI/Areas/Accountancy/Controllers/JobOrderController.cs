using Merp.Web.UI.Areas.Accountancy.Models.JobOrder;
using Merp.Web.UI.Areas.Accountancy.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;

namespace Merp.Web.UI.Areas.Accountancy.Controllers
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
            return Redirect("/Accountancy/JobOrder");
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
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult ExtendTimeAndMaterial()
        {
            var model = new ExtendTimeAndMaterialViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ExtendTimeAndMaterial(ExtendTimeAndMaterialViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.ExtendJobOrder(model);
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var model = WorkerServices.GetList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}