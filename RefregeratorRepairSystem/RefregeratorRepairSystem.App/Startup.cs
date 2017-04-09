﻿using System;
using Microsoft.Owin;
using Owin;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Account;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Models.ViewModels.Employees;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;

[assembly: OwinStartupAttribute(typeof(RefregeratorRepairSystem.App.Startup))]
namespace RefregeratorRepairSystem.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutommapper();
            ConfigureAuth(app);
        }

        private void ConfigureAutommapper()
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
                        configuretionExpress =>
                            configuretionExpress.MapFrom(
                                repair => repair.Customer.FirstName + " " + repair.Customer.LastName))
                    .ForMember(vm => vm.Employee,
                        configuretionExpress =>
                            configuretionExpress.MapFrom(
                                repair => repair.Employee.FirstName + " " + repair.Employee.LastName))
                    .ForMember(vm => vm.Item,
                        configuretionExpress =>
                            configuretionExpress.MapFrom(
                                repair => repair.Item.Type));

            });
        }
    }
}
