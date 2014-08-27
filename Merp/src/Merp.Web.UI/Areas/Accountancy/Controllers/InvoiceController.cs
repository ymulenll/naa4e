using Merp.Web.UI.Areas.Accountancy.Models.Invoice;
using Merp.Web.UI.Areas.Accountancy.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;

namespace Merp.Web.UI.Areas.Accountancy.Controllers
{
    public class InvoiceController : Controller
    {
        public InvoiceControllerWorkerServices WorkerServices { get; private set; }

        public InvoiceController(InvoiceControllerWorkerServices workerServices)
        {
            if(workerServices==null)
            {
                throw new ArgumentNullException("workerServices");
            }
            WorkerServices = workerServices;
        }

        [HttpGet]
        public ActionResult Issue()
        {
            var model = WorkerServices.GetIssueViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Issue(IssueViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.Issue(model);
            return Redirect("/Accountancy/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = WorkerServices.GetRegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            WorkerServices.Register(model);
            return Redirect("/Accountancy/");
        }

        [HttpGet]
        public ActionResult GetListOfIncomingInvoicesNotAssignedToAJobOrder()
        {
            var model = WorkerServices.GetListOfIncomingInvoicesNotAssignedToAJobOrder();
            return this.Jsonp(model);
        }

        [HttpGet]
        public ActionResult IncomingInvoicesNotAssignedToAJobOrder()
        {
            var model = new IncomingInvoicesNotAssignedToAJobOrderViewModel();
            return View(model);
        }

        public ActionResult AssignIncomingInvoiceToJobOrder()
        {
            return View();
        }
    }
}