namespace RefregeratorRepairSystem.Models.ViewModels.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RefregeratorRepairSystem.Models.ViewModels.Parts;

    public class AddItemViewModel
    {

        public AddItemViewModel()
        {
            this.Types = new HashSet<string>();
            this.Parts = new HashSet<PartForItemVIewModel>();
        }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string Make { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string Model { get; set; }

        public ICollection<string> Types { get; set; }

        public  ICollection<PartForItemVIewModel> Parts { get; set; } 
    }
}
