using System.Collections.Generic;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.ViewModels.Customers;
using RefregeratorRepairSystem.Models.ViewModels.Employees;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IAdministratorService
    {
        IEnumerable<ListCustomerViewModel> GetAllCustomers();
        IEnumerable<ListEmployeeViewModel> GetAllEmployees();
        CustomerToEmployeeViewModel TakeACustomertoMakeEmployee(int id);
        EmployeeForFiredViewModel TakeAnEmployeeForFired(int id);
        void TransformCustomerToEmployee(CreateEmployeeBindingModel model);
        void FiredAnEmployee(FiredEmployeeBindingModel model);
        void DeleteUser(string id);
        RefregeratorRepairSystemContext Context { get; set; }
    }
}