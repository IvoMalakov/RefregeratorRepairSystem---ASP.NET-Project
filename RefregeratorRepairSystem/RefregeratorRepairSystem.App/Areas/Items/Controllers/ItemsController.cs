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
using RefregeratorRepairSystem.Models.ViewModels.Items;
using RefregeratorRepairSystem.Services;

namespace RefregeratorRepairSystem.App.Areas.Items.Controllers
{
    [Authorize]
    [RoutePrefix("Items")]
    public class ItemsController : Controller
    {
        private RefregeratorRepairSystemContext db = new RefregeratorRepairSystemContext();
        private ItemsService service = new ItemsService();

        [Route("AllItems")]
        public ActionResult AllItems()
        {
            IEnumerable<ListItemsViewModel> viewModels = this.service.GetAllItems();
            return View("~/Areas/Items/Views/AllItems.cshtml", viewModels);
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Add")]
        public ActionResult Add()
        {
            AddItemViewModel viewModel = this.service.GetItemDetailsForAdd();
            return View("~/Areas/Items/Views/Add.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Make, Model, Type, Part1, Part2, Part3")] AddItemBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddItem(bindingModel);
                return this.RedirectToAction("AllItems");
            }

            return this.RedirectToAction("Add");
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditItemViewModel viewModel = this.service.GetItemForEdition(id);
            return View("~/Areas/Items/Views/Edit.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Make, Model")] EditItemBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.EditItem(bindingModel);
                return this.RedirectToAction("AllItems");
            }

            return this.RedirectToAction("Edit", "Items", new {id = bindingModel.Id});
        }

        [HttpGet]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeleteItemViewModel viewModel = this.service.GetItemForDeletion(id);
            return View("~/Areas/Items/Views/Delete.cshtml", viewModel);
        }

        [HttpPost]
        [MyAuthorize(Roles = "Administrator, Employee")]
        [Route("Delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")] DeleteItemBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.DeleteItem(bindingModel);
                return this.RedirectToAction("AllItems");
            }

            return this.RedirectToAction("Delete", "Items", new {id = bindingModel.Id});
        }

        [Route("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            DetailedItemVIewModel viewModel = this.service.GetItemDetails(id);
            return View("~/Areas/Items/Views/Details.cshtml", viewModel);
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
