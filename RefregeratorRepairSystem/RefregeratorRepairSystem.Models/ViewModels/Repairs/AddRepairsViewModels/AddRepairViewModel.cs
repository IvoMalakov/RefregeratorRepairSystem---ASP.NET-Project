namespace RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels
{
    using System.Collections.Generic;

    public class AddRepairViewModel
    {
        public AddRepairViewModel()
        {
            this.Customers = new HashSet<CustomerRepairViewModel>();
            this.Items = new HashSet<ItemRepairViewModel>();
            this.Employees = new HashSet<EmployeeRepairViewModel>();
        }

        public string ActionsTaken { get; set; }

        public decimal Price { get; set; }

        public ICollection<CustomerRepairViewModel> Customers { get; set; }

        public ICollection<ItemRepairViewModel> Items { get; set; }

        public ICollection<EmployeeRepairViewModel> Employees { get; set; }
    }
}
