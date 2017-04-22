using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.Enums;
using RefregeratorRepairSystem.Models.ViewModels.Account;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Models.ViewModels.Employees;
using RefregeratorRepairSystem.Models.ViewModels.Items;
using RefregeratorRepairSystem.Models.ViewModels.Parts;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;
using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;

namespace RefregeratorRepairSystem.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureAutommapper(Data.Data.Context);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureAutommapper(RefregeratorRepairSystemContext context)
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterViewModel, Customer>();
                expression.CreateMap<Customer, ListCustomerViewModel>();
                expression.CreateMap<Customer, CustomerToEmployeeViewModel>();
                expression.CreateMap<CreateEmployeeBindingModel, Employee>();
                expression.CreateMap<Employee, ListEmployeeViewModel>();
                expression.CreateMap<Employee, EmployeeForFiredViewModel>();

                expression.CreateMap<Repair, ListRepairsViewModel>()
                    .ForMember(vm => vm.Customer,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Customer.FirstName + " " + repair.Customer.LastName))
                    .ForMember(vm => vm.EmployeeInCharge,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.EmployeeInCharge.FirstName + " " + repair.EmployeeInCharge.LastName))
                    .ForMember(vm => vm.Item,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Item.Type));

                expression.CreateMap<Customer, CustomerRepairViewModel>()
                    .ForMember(vm => vm.Name,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                customer => customer.FirstName + " " + customer.LastName));

                expression.CreateMap<Employee, EmployeeRepairViewModel>()
                    .ForMember(vm => vm.Name,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                employee => employee.FirstName + " " + employee.LastName));

                expression.CreateMap<Item, ItemRepairViewModel>()
                    .ForMember(vm => vm.Name,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                item => item.Make + " " + item.Model));

                expression.CreateMap<AddRepairBindingModel, Repair>()
                    .ForMember(vm => vm.Customer,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => context.Customers.Find(repair.CustomerId)))
                    .ForMember(vm => vm.EmployeeInCharge,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => context.Employees.Find(repair.EmployeeId)))
                    .ForMember(vm => vm.Item,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => context.Items.Find(repair.ItemId)));

                expression.CreateMap<Repair, DetailedRepairViewModel>()
                 .ForMember(vm => vm.Customer,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Customer.FirstName + " " + repair.Customer.LastName))
                    .ForMember(vm => vm.EmployeeInCharge,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.EmployeeInCharge.FirstName + " " + repair.EmployeeInCharge.LastName))
                    .ForMember(vm => vm.RepairItem,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Item.Type + " - " + repair.Item.Make + " " + repair.Item.Model));

                expression.CreateMap<Repair, EditRepairViewModel>();
                expression.CreateMap<Part, PartForItemViewModel>();

                expression.CreateMap<Repair, DeleteRepairViewModel>()
                    .ForMember(vm => vm.Customer,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Customer.FirstName + " " + repair.Customer.LastName))
                    .ForMember(vm => vm.Item,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                repair => repair.Item.Type + " - " + repair.Item.Make + " " + repair.Item.Model));

                expression.CreateMap<AddItemBindingModel, Item>()
                    .ForMember(it => it.Type,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                bm => Enum.Parse(typeof(ItemType), bm.Type)));

                expression.CreateMap<Item, ListItemsViewModel>();
                expression.CreateMap<Item, EditItemViewModel>();
                expression.CreateMap<Item, DeleteItemViewModel>();
                expression.CreateMap<Item, DetailedItemViewModel>();
                expression.CreateMap<Part, ListPartsViewModel>();

                expression.CreateMap<Item, ItemForPartViewModel>()
                    .ForMember(vm => vm.ItemDescription,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                item => item.Type + " - " + item.Make + " " + item.Model));

                expression.CreateMap<AddPartBindingModel, Part>();
                expression.CreateMap<Part, DetailedPartViewModel>();

                expression.CreateMap<Part, EditPartViewModel>()
                    .ForMember(vm => vm.PartDescription,
                        configurationExpress =>
                            configurationExpress.MapFrom(
                                part => part.Name + " " + part.Model));

                expression.CreateMap<Part, DeletePartViewModel>();
            });
        }
    }
}
