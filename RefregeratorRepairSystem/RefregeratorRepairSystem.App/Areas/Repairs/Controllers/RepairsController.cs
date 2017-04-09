using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RefregeratorRepairSystem.App.Attributes;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;
using RefregeratorRepairSystem.Services;

namespace RefregeratorRepairSystem.App.Areas.Repairs.Controllers
{
    [MyAuthorize(Roles = "Administrator, Employee")]
    [RoutePrefix("Repairs")]
    public class RepairsController : Controller
    {
        private RefregeratorRepairSystemContext db = new RefregeratorRepairSystemContext();
        private RepairsService service = new RepairsService();

        [Route("allRepairs")]
        public ActionResult AllRepairs()
        {
            IEnumerable<ListRepairsViewModel> viewModels = this.service.GetAllRepairs();
            return View("~/Areas/Repairs/Views/AllRepairs.cshtml", viewModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
