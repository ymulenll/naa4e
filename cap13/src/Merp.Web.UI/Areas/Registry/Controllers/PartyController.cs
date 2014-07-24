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

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetParties()
        {
            var model = new List<object>
                {
                    new {name = "Andrea Saltarello", id = 1},
                    new {name = "Managed designs S.r.l.", id = 2},
                    new {name = "Enos Recanati", id = 3},
                    new {name = "Mauro Servienti", id = 4}
                };

            return this.Jsonp(model);
        }
    }
}