using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Services;

namespace RefregeratorRepairSystem.App.Areas.Parts.Controllers
{
    public class PartsController : Controller
    {
        private RefregeratorRepairSystemContext db = new RefregeratorRepairSystemContext();
        private PartsService service = new PartsService();

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
