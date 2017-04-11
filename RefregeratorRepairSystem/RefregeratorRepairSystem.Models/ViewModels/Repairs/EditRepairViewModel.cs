namespace RefregeratorRepairSystem.Models.ViewModels.Repairs
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;

    public class EditRepairViewModel
    {
        public EditRepairViewModel()
        {
            this.Employees = new HashSet<EmployeeRepairViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string ActionsTaken { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "2000.00", ErrorMessage = "The price can not be negative")]
        public decimal Price { get; set; }

        public ICollection<EmployeeRepairViewModel> Employees { get; set; }
    }
}
