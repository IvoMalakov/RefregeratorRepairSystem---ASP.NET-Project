using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Models.ViewModels.Employees;

namespace RefregeratorRepairSystem.Services
{
    public class AdministratorService : Service
    {
        public IEnumerable<ListCustomerViewModel> GetAllCustomers()
        {
            IEnumerable<ListCustomerViewModel> allCustomers = new HashSet<ListCustomerViewModel>();

            IList<Customer> customers = this.Context
                .Customers
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();

            allCustomers = Mapper.Map<IEnumerable<Customer>, IEnumerable<ListCustomerViewModel>>(customers);

            return allCustomers;
        }

        public IEnumerable<ListEmployeeViewModel> GetAllEmployees()
        {
            IEnumerable<ListEmployeeViewModel> allEmployees = new HashSet<ListEmployeeViewModel>();

            IList<Employee> employees = this.Context
                .Employees
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            allEmployees = Mapper.Map<IEnumerable<Employee>, IEnumerable<ListEmployeeViewModel>>(employees);

            return allEmployees;
        }

        public CustomerToEmployeeViewModel TakeACustomertoMakeEmployee(int id)
        {
            Customer customer = this.Context.Customers.Find(id);
            CustomerToEmployeeViewModel viewModel = Mapper.Map<CustomerToEmployeeViewModel>(customer);

            return viewModel;
        }

        public EmployeeForFiredViewModel TakeAnEmployeeForFired(int id)
        {
            Employee employee = this.Context.Employees.Find(id);
            EmployeeForFiredViewModel viewModel = Mapper.Map<EmployeeForFiredViewModel>(employee);

            return viewModel;
        }

        public void TransformCustomerToEmployee(CreateEmployeeBindingModel model)
        {
            Customer customer = this.Context.Customers.Find(model.Id);
            Employee employee = Mapper.Map<Employee>(model);
            employee.ApplicationUser = customer.ApplicationUser;

            this.Context.Customers.Remove(customer);
            this.Context.Employees.Add(employee);
            this.Context.SaveChanges();
        }

        public void FiredAnEmployee(FiredEmployeeBindingModel model)
        {
            Employee employee = this.Context.Employees.Find(model.Id);
            this.Context.Employees.Remove(employee);
            this.Context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            ApplicationUser user = this.Context.Users.Find(id);
            this.Context.Users.Remove(user);
            this.Context.SaveChanges();
        }
    }
}
