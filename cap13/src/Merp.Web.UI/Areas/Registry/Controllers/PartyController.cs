using Merp.Web.UI.Areas.Registry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;
using Merp.Web.UI.Areas.Registry.WorkerServices;

namespace Merp.Web.UI.Areas.Registry.Controllers
{
    public class PartyController : Controller
    {
        public PartyControllerWorkerServices WorkerServices { get; private set; }

        public PartyController(PartyControllerWorkerServices workerServices)
        {
            if(workerServices==null)
            {
                throw new ArgumentNullException("workerServices");
            }
            WorkerServices = workerServices;
        }

        [HttpGet]
        public ActionResult GetPartyInfoByPattern(string text)
        {
            var model = WorkerServices.GetNamesByPattern(text);
            return this.Jsonp(model);
        }

        [HttpGet]
        public ActionResult GetPartyInfoById(int id)
        {
            var model = WorkerServices.GetPartyInfoByPattern(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}