using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string ActionsTaken { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "2000.00", ErrorMessage = "The price can not be negative")]
        public decimal Price { get; set; }

        public ICollection<CustomerRepairViewModel> Customers { get; set; }

        public ICollection<ItemRepairViewModel> Items { get; set; }

        public ICollection<EmployeeRepairViewModel> Employees { get; set; }
    }
}
