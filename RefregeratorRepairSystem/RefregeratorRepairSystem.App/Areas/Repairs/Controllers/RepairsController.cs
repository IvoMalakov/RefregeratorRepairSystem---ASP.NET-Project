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
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;
using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;
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

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            AddRepairViewModel addRepairViewModel = this.service.GetAllRepairDetailsForAdd();
            return View("~/Areas/Repairs/Views/Add.cshtml", addRepairViewModel);
        }

        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(
            [Bind(Include = "Price, ActionsTaken, CustomerId, EmployeeId, ItemId")] AddRepairBindingModel model)
        {
            if (ModelState.IsValid)
            {
                this.service.AddRepair(model);
                return this.RedirectToAction("AllRepairs");
            }

            return this.RedirectToAction("Add");
        }

        [HttpGet]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditRepairViewModel viewModel = this.service.GetEditedRepair(id);
            return View("~/Areas/Repairs/Views/Edit.cshtml", viewModel);
        }

        [HttpPost]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Price, ActionsTaken, EmployeeId")] EditRepairBindingModel model)
        {
            if (ModelState.IsValid)
            {
                this.service.EditRepair(model);
                return this.RedirectToAction("AllRepairs");
            }

            return this.RedirectToAction("Edit", "Repairs", new {id = model.Id});
        }

        [HttpGet]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeleteRepairViewModel viewModel = this.service.GetRepairForDeletion(id);
            return View("~/Areas/Repairs/Views/Delete.cshtml", viewModel);
        }

        [HttpPost]
        [Route("Delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")] DeleteRepairBindingModel model)
        {
            if (ModelState.IsValid)
            {
                this.service.DeleteRepair(model);
                return this.RedirectToAction("AllRepairs");
            }

            return this.RedirectToAction("Delete", "Repairs", new {id = model.Id});
        }

        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            DetailedRepairViewModel viewModel = this.service.GetRepairDetails(id);
            return View("~/Areas/Repairs/Views/Details.cshtml", viewModel);
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
