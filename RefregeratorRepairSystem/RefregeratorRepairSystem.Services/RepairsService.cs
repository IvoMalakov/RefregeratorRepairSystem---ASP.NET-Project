using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;
using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;
using RefregeratorRepairSystem.Services.Interfaces;

namespace RefregeratorRepairSystem.Services
{
    public class RepairsService : Service, IRepairsService
    {
        public IEnumerable<ListRepairsViewModel> GetAllRepairs()
        {
            IEnumerable<Repair> repairs = this.Context
                .Repairs
                .OrderBy(r => r.Customer.FirstName)
                .ThenByDescending(r => r.Price)
                .ToList();

            IEnumerable<ListRepairsViewModel> repairsViewModels =
                Mapper.Map<IEnumerable<Repair>, IEnumerable<ListRepairsViewModel>>(repairs);

            return repairsViewModels;
        }

        public AddRepairViewModel GetAllRepairDetailsForAdd()
        {
            AddRepairViewModel addRepairViewModel = new AddRepairViewModel();

            var allCustomers = this.Context.Customers.ToList();
            var allEmployees = this.Context.Employees.ToList();
            var allItems = this.Context.Items.ToList();

            foreach (Customer customer in allCustomers)
            {
                CustomerRepairViewModel customerRepairViewModel = Mapper.Map<CustomerRepairViewModel>(customer);
                addRepairViewModel.Customers.Add(customerRepairViewModel);
            }

            foreach (Employee employee in allEmployees)
            {
                EmployeeRepairViewModel employeeRepairView = Mapper.Map<EmployeeRepairViewModel>(employee);
                addRepairViewModel.Employees.Add(employeeRepairView);
            }

            foreach (Item item in allItems)
            {
                ItemRepairViewModel itemRepairViewModel = Mapper.Map<ItemRepairViewModel>(item);
                addRepairViewModel.Items.Add(itemRepairViewModel);
            }

            return addRepairViewModel;
        }

        public void AddRepair(AddRepairBindingModel model)
        {
            Repair repair = Mapper.Map<Repair>(model);
            this.Context.Repairs.Add(repair);
            this.Context.SaveChanges();
        }

        public DetailedRepairViewModel GetRepairDetails(int id)
        {
            Repair repair = this.Context.Repairs.Find(id);
            DetailedRepairViewModel viewModel = Mapper.Map<DetailedRepairViewModel>(repair);

            return viewModel;
        }

        public EditRepairViewModel GetEditedRepair(int id)
        {
            Repair repair = this.Context.Repairs.Find(id);
            var allEmployees = this.Context.Employees.ToList();

            EditRepairViewModel viewModel = Mapper.Map<EditRepairViewModel>(repair);

            foreach (Employee employee in allEmployees)
            {
                EmployeeRepairViewModel employeeRepairView = Mapper.Map<EmployeeRepairViewModel>(employee);
                viewModel.Employees.Add(employeeRepairView);
            }

            return viewModel;
        }

        public void EditRepair(EditRepairBindingModel model)
        {
            Repair repair = this.Context.Repairs.Find(model.Id);

            if (repair != null)
            {
                repair.Price = model.Price;
                repair.ActionsTaken = model.ActionsTaken;
                repair.EmployeeInCharge = this.Context.Employees.Find(model.EmployeeId);

                this.Context.SaveChanges();
            }
        }

        public DeleteRepairViewModel GetRepairForDeletion(int id)
        {
            Repair repair = this.Context.Repairs.Find(id);
            DeleteRepairViewModel viewModel = Mapper.Map<DeleteRepairViewModel>(repair);

            return viewModel;
        }

        public void DeleteRepair(DeleteRepairBindingModel model)
        {
            Repair repair = this.Context.Repairs.Find(model.Id);
            this.Context.Repairs.Remove(repair);
            this.Context.SaveChanges();
        }
    }
}
