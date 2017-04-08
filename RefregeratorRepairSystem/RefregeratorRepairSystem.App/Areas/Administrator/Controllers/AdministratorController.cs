using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Models.ViewModels.Employees;
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

        [Route("Home")]
        public ActionResult Home()
        {
            return View("~/Areas/Administrator/Views/Home.cshtml");
        }

        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<ListCustomerViewModel> customerViewModels = this.service.GetAllCustomers();
            return View("~/Areas/Administrator/Views/Index.cshtml", customerViewModels);
        }

        [Route("AllEmployees")]
        public ActionResult AllEmployees()
        {
            IEnumerable<ListEmployeeViewModel> employeeViewModels = this.service.GetAllEmployees();
            return View("~/Areas/Administrator/Views/AllEmployees.cshtml", employeeViewModels);
        }

        [Route("createEmployee/{id:int}")]
        public ActionResult CreateEmployee(int id)
        {
            CustomerToEmployeeViewModel viewModel = this.service.TakeACustomertoMakeEmployee(id);
            return View("~/Areas/Administrator/Views/CreateEmployee.cshtml", viewModel);
        }

        [Route("firedEmployee/{id:int}")]
        public ActionResult FiredEmployee(int id)
        {
            EmployeeForFiredViewModel viewModel = this.service.TakeAnEmployeeForFired(id);
            return View("~/Areas/Administrator/Views/FiredEmployee.cshtml", viewModel);
        }

        [HttpPost]
        [Route("createEmployee/{id:int}")]
        public ActionResult CreateEmployee(
            [Bind(Include = "Id, FirstName, LastName, Salary, Address, ApplicationUser")] CreateEmployeeBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.TransformCustomerToEmployee(model);
                //ApplicationUser user = UserManager.FindByName(this.User.Identity.Name);
                //UserManager.AddToRole(user.Id, "Employee");
                //UserManager.RemoveFromRole(user.Id, "Customer");
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("CreateEmployee", "Administrator", new {id = model.Id});
        }

        [HttpPost]
        [Route("firedEmployee/{id:int}")]
        public ActionResult FiredEmployee(
            [Bind(Include = "Id, FirstName, LastName, Address, Salary, ApplicationUser")] FiredEmployeeBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.FiredAnEmployee(model);
                //ApplicationUser user = UserManager.FindByName(this.User.Identity.Name);
                //UserManager.RemoveFromRole(user.Id, "Employee");
                //this.service.DeleteUser(user.Id);
                return this.RedirectToAction("AllEmployees");
            }

            return this.RedirectToAction("FiredEmployee", "Administrator", new {id = model.Id});
        }
    }
}