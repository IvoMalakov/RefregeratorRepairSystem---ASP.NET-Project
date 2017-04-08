using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Customers;

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

        public CustomerToEmployeeViewModel TakeACustomertoMakeEmployee(int id)
        {
            Customer customer = this.Context.Customers.Find(id);
            CustomerToEmployeeViewModel viewModel = Mapper.Map<CustomerToEmployeeViewModel>(customer);

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
    }
}
