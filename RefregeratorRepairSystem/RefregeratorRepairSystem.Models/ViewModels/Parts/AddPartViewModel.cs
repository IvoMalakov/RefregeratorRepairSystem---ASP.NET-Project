namespace RefregeratorRepairSystem.Models.ViewModels.Parts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RefregeratorRepairSystem.Models.ViewModels.Items;

    public class AddPartViewModel
    {
        public AddPartViewModel()
        {
            this.Items = new HashSet<ItemForPartViewModel>();
        }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters log", MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "2000.00", ErrorMessage = "The price can not be negative")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(int), "0", "1000", ErrorMessage = "The quantity can not be negative")]
        public int Quantity { get; set; }

        public virtual ICollection<ItemForPartViewModel> Items { get; set; } 
    }
}
