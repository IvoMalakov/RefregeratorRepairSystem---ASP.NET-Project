namespace RefregeratorRepairSystem.Models.ViewModels.Repairs
{
    using System.Collections.Generic;
    using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;

    public class EditRepairViewModel
    {
        public EditRepairViewModel()
        {
            this.Employees = new HashSet<EmployeeRepairViewModel>();
        }

        public string ActionsTaken { get; set; }

        public decimal Price { get; set; }

        public ICollection<EmployeeRepairViewModel> Employees { get; set; }
    }
}
