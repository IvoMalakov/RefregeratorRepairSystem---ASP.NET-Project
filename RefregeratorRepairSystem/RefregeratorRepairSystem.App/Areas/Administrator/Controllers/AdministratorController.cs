using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Services;

namespace RefregeratorRepairSystem.App.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [RoutePrefix("Administrator")]
    public class AdministratorController : Controller
    {
        private AdministratorService service;
        private ApplicationUserManager _userManager;

        public AdministratorController()
        {
            this.service = new AdministratorService();
        }

        public AdministratorController(ApplicationUserManager usermanager) : this()
        {
            this.UserManager = usermanager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<ListCustomerViewModel> customerViewModels = this.service.GetAllCustomers();
            return View("~/Areas/Administrator/Views/Index.cshtml", customerViewModels);
        }

        [Route("createEmployee/{id:int}")]
        public ActionResult CreateEmployee(int id)
        {
            CustomerToEmployeeViewModel viewModel = this.service.TakeACustomertoMakeEmployee(id);
            return this.View("~/Areas/Administrator/Views/CreateEmployee.cshtml", viewModel);
        }

        [HttpPost]
        [Route("createEmployee/{id:int}")]
        public ActionResult CreateEmployee(
            [Bind(Include = "Id, FirstName, LastName, Salary, ApplicationUser")] CreateEmployeeBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.TransformCustomerToEmployee(model);
                IdentityUser user = UserManager.FindByName(this.User.Identity.Name);
                UserManager.AddToRole(user.Id, "Employee");
                UserManager.RemoveFromRole(user.Id, "Customer");
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("CreateEmployee", "Administrator", new {id = model.Id});
        }
    }
}