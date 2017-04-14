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
using RefregeratorRepairSystem.Models.ViewModels.Parts;
using RefregeratorRepairSystem.Services;

namespace RefregeratorRepairSystem.App.Areas.Parts.Controllers
{
    [Authorize]
    [RoutePrefix("Parts")]
    public class PartsController : Controller
    {
        private RefregeratorRepairSystemContext db = new RefregeratorRepairSystemContext();
        private PartsService service = new PartsService();

        [Route("AllParts")]
        public ActionResult AllParts()
        {
            IEnumerable<ListPartsViewModel> viewModels = this.service.GetAllParts();
            return View("~/Areas/Parts/Views/AllParts.cshtml", viewModels);
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Add")]
        public ActionResult Add()
        {
            AddPartViewModel viewModel = this.service.GetPartDetailsForAdd();
            return View("~/Areas/Parts/Views/Add.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Add")]
        public ActionResult Add(
            [Bind(Include = "Name, Model, Price, Quantity, ItemId")] AddPartBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddPart(bindingModel);
                return this.RedirectToAction("AllParts");
            }

            return this.RedirectToAction("Add");
        }

        [Route("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            DetailedPartViewModel viewModel = this.service.GetPartDetails(id);
            return View("~/Areas/Parts/Views/Details.cshtml", viewModel);
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditPartViewModel viewModel = this.service.GetPartForEdition(id);
            return View("~/Areas/Parts/Views/Edit.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.EditPart(bindingModel);
                return this.RedirectToAction("AllParts");
            }

            return this.RedirectToAction("Edit", "Parts", new {id = bindingModel.Id});
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeletePartViewModel viewModel = this.service.GetPartForDeletion(id);
            return View("~/Areas/Parts/Views/Delete.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")] DeletePartBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.DeletePart(bindingModel);
                return this.RedirectToAction("AllParts");
            }

            return this.RedirectToAction("Delete", "Parts", new {id = bindingModel.Id});
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
