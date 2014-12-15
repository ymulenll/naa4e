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
        public ActionResult GetList()
        {
            var model = WorkerServices.GetList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            switch (WorkerServices.GetDetailViewModel(id.Value))
            {
                case "FixedPrice":
                    return Redirect(string.Format("/Accountancy/JobOrder/FixedPriceJobOrderDetail/{0}", id));
                case "TimeAndMaterial":
                    return Redirect(string.Format("/Accountancy/JobOrder/TimeAndMaterialJobOrderDetail/{0}", id));
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult BalanceTrendAnalysis()
        {
            return View();
        }

        #region Fixed Price Job Orders
        [HttpGet]
        public ActionResult CreateFixedPrice()
        {
            var model = WorkerServices.GetCreateFixedPriceViewModel();
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

        public ActionResult FixedPriceJobOrderDetail(Guid? id)
        {
            var model = WorkerServices.GetFixedPriceJobOrderDetailViewModel(id.Value);
            return View(model);
        }

        [HttpGet]
        public ActionResult ExtendFixedPrice(Guid? id)
        {
            var model = WorkerServices.GetExtendFixedPriceViewModel(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult ExtendFixedPrice(ExtendFixedPriceViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.ExtendFixedPriceJobOrder(model);
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult MarkFixedPriceJobOrderAsCompleted(Guid? id)
        {
            var model = WorkerServices.GetMarkFixedPriceJobOrderAsCompletedViewModel(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult MarkFixedPriceJobOrderAsCompleted(MarkFixedPriceJobOrderAsCompletedViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.MarkFixedPriceJobOrderAsCompleted(model);
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult EvaluateFixedPriceJobOrderBalance(Guid id)
        {
            var model = WorkerServices.GetEvaluateFixedPriceJobOrderBalance(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Time And Material Job Orders
        [HttpGet]
        public ActionResult CreateTimeAndMaterial()
        {
            var model = WorkerServices.GetCreateTimeAndMaterialViewModel();
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

        public ActionResult TimeAndMaterialJobOrderDetail(Guid? id)
        {
            var model = WorkerServices.GetTimeAndMaterialJobOrderDetailViewModel(id.Value);
            return View(model);
        }

        [HttpGet]
        public ActionResult ExtendTimeAndMaterial(Guid? id)
        {
            var model = WorkerServices.GetExtendTimeAndMaterialViewModel(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult ExtendTimeAndMaterial(ExtendTimeAndMaterialViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.ExtendTimeAndMaterialJobOrder(model);
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult MarkTimeAndMaterialJobOrderAsCompleted(Guid? id)
        {
            var model = WorkerServices.GetMarkTimeAndMaterialJobOrderAsCompletedViewModel(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult MarkTimeAndMaterialJobOrderAsCompleted(MarkTimeAndMaterialJobOrderAsCompletedViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.MarkTimeAndMaterialJobOrderAsCompleted(model);
            return Redirect("/Accountancy/JobOrder");
        }

        [HttpGet]
        public ActionResult EvaluateTimeAndMaterialJobOrderBalance(Guid id)
        {
            var model = WorkerServices.GetEvaluateTimeAndMaterialJobOrderBalance(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
    }
}